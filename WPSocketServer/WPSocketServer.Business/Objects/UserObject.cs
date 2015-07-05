using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPSocket;
using WPSocketServer.Business.Enums;
using WPSocketServer.Business.Helpers;
using WPSocketServer.Business.Models;
namespace WPSocketServer.Business.Objects {
    public class UserObject {
        public event ProcessErrorEventHandler ProcessError;
        public delegate void ProcessErrorEventHandler(Exception ex, string func);
        /// <summary>
        /// User Model
        /// </summary>
        public UserModel UserModel { get; set; }
        /// <summary>
        /// Authenticated
        /// </summary>
        public bool Authenticated { get; set; }
        /// <summary>
        /// The users socket
        /// </summary>
        private AsyncSocket _socket;
        /// <summary>
        /// Connected
        /// </summary>
        public bool Connected {
            get {
                try {
                    if (_socket != null) {
                        return _socket.Connected;
                    } else {
                        return false;
                    }
                } catch (Exception ex) {
                    if (ProcessError != null) {
                        ProcessError(ex, "Connected");
                    }
                    return false;
                }
            }
        }
        /// <summary>
        /// Close Socket
        /// </summary>
        /// <returns></returns>
        public bool CloseSocket() {
            try {
                _socket.Close();
                return true;
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "CloseSocket");
                }
                return false;
            }
        }
        /// <summary>
        /// Entry point
        /// </summary>
        public UserObject() { }
        /// <summary>
        /// Set socket
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        public bool SetSocket(AsyncSocket socket) {
            try {
                _socket = socket;
                _socket.CouldNotConnect += _socket_CouldNotConnect;
                _socket.SocketConnected += _socket_SocketConnected;
                _socket.SocketDataArrival += _socket_SocketDataArrival;
                _socket.SocketDisconnected += _socket_SocketDisconnected;
                _socket.SocketError += _socket_SocketError;
                UserModel = new Models.UserModel();
                return true;
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "SetSocket");
                }
                return false;
            }
        }
        /// <summary>
        /// Socket Error
        /// </summary>
        /// <param name="_ex"></param>
        private void _socket_SocketError(Exception _ex) {
            try {
                GlobalObjects.Users.Destroy(this); // DISCONNECTED, LETS EMPTY THE MEMORY ITEM!
            } catch(Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "_socket_SocketError");
                }
            }
        }
        /// <summary>
        /// Send Socket
        /// </summary>
        /// <param name="data"></param>
        public void SendSocket(string data) {
            try {
                _socket.Send(data);
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "SendSocket");
                }
            }
        }
        /// <summary>
        /// Socket Disconnected
        /// </summary>
        /// <param name="SocketID"></param>
        private void _socket_SocketDisconnected(string SocketID) {
            try {
                GlobalObjects.Users.Destroy(this); // DISCONNECTED, LETS EMPTY THE MEMORY ITEM!
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "_socket_SocketDisconnected");
                }
            }
        }
        /// <summary>
        /// Socket Data Arrival
        /// </summary>
        /// <param name="SocketID"></param>
        /// <param name="SocketData"></param>
        /// <param name="lBytes"></param>
        /// <param name="lBytesRead"></param>
        private void _socket_SocketDataArrival(string SocketID, string SocketData, byte[] lBytes, int lBytesRead) {
            try {
                var connectionId = 0;
                var splt = SocketData.Split((char)13);
                foreach (var line in splt) {
                    var splt2 = line.Split(' ');
                    switch (splt2[0]) {
                        case "auth":
                            var _userId = UsersHelper.Authenticate(splt2[1], splt2[2]);
                            if (_userId != 0) {
                                UserModel.UserId = _userId;
                                UserModel.EmailAddress = splt2[1];
                                UserModel.Password = splt2[2];
                                Authenticated = true;
                                _socket.Send("msg:Authentication Success");
                            } else {
                                _socket.Send("msg:Authentication Failure; Bad EmailAddress or password.");
                            }
                            break;
                        case "list":
                            if (Connected && Authenticated) {
                                var conn = GlobalObjects.UserSockets.Get(UserModel.UserId);
                                if (conn.Count() != 0) {
                                    _socket.Send("msg:Begin Connections List");
                                    foreach (var connection in conn) {
                                        _socket.Send("con:" + connection.Model.ConnectionId.ToString() + ";" + connection.Model.Connected.ToString() + ":" + connection.Model.Description + ";" + connection.Model.Server + ";" + connection.Model.Port.ToString());
                                    }
                                    _socket.Send("msg:End Connections List");
                                } else {
                                    _socket.Send("msg:0 Connections");
                                }
                            } else {
                                _socket.Send("msg:Must authenticate first.");
                            }
                            break;
                        case "stopmonitoring":
                            if (int.TryParse(splt2[1], out connectionId)) {
                                if (Connected && Authenticated) {
                                    if (GlobalObjects.UserSockets.StopMonitoring(connectionId, UserModel.UserId)) {
                                        _socket.Send("msg:Stopped monitoring " + connectionId.ToString());
                                    } else {
                                        _socket.Send("msg:Could not stop monitoring " + connectionId.ToString());
                                    }
                                } else {
                                    _socket.Send("msg:Must authenticate first.");
                                }
                            }
                            break;
                        case "monitor":
                            if (int.TryParse(splt2[1], out connectionId)) {
                                if (Connected && Authenticated) {
                                    if (GlobalObjects.UserSockets.Monitor(connectionId, UserModel.UserId)) {
                                        _socket.Send("msg:Now monitoring " + connectionId.ToString());
                                    } else {
                                        _socket.Send("msg:Could not monitor " + connectionId.ToString());
                                    }
                                } else {
                                    _socket.Send("msg:Must authenticate first.");
                                }
                            }
                            break;
                        case "create": // Create a connection to a server
                            if (Connected && Authenticated) {
                                var server = splt2[1];
                                var port = int.Parse(splt2[2]);
                                var serviceType = int.Parse(splt2[3]);
                                if (!string.IsNullOrEmpty(server)) {
                                    if (port != 0) {
                                        connectionId = GlobalObjects.UserSockets.Create("", UserModel.UserId, server, port, serviceType);
                                        if (connectionId != 0) {
                                            _socket.Send("msg:Created " + connectionId.ToString());
                                        } else {
                                            _socket.Send("msg:Could not create " + connectionId.ToString());
                                        }
                                    } else {
                                        _socket.Send("msg:Port cannot be 0." + connectionId.ToString());
                                    }
                                } else {
                                    _socket.Send("msg:Server cannot be empty." + connectionId.ToString());
                                }
                            } else {
                                _socket.Send("msg:Must authenticate first.");
                            }
                            break;
                        case "connect":
                            if (int.TryParse(splt2[1], out connectionId)) {
                                if (Connected && Authenticated) {
                                    if (GlobalObjects.UserSockets.Connect(connectionId, UserModel.UserId)) {
                                        _socket.Send("msg:Connecting to " + connectionId.ToString());
                                    } else {
                                        _socket.Send("msg:Could not Connect to " + connectionId.ToString());
                                    }
                                } else {
                                    _socket.Send("msg:Must authenticate first.");
                                }
                            }
                            break;
                        case "destroy":
                            if (int.TryParse(splt2[1], out connectionId)) {
                                if (Connected && Authenticated) {
                                    if (GlobalObjects.UserSockets.Destroy(connectionId, UserModel.UserId)) {
                                        _socket.Send("msg:Destroyed " + connectionId.ToString());
                                    } else {
                                        _socket.Send("msg:Could not Destroy " + connectionId.ToString());
                                    }
                                } else {
                                    _socket.Send("msg:Must authenticate first.");
                                }
                            }
                            break;
                        case "disconnect":
                            if (int.TryParse(splt2[1], out connectionId)) {
                                if (Connected && Authenticated) {
                                    if (GlobalObjects.UserSockets.Disconnect(connectionId, UserModel.UserId)) {
                                        _socket.Send("msg:Disconnected from " + connectionId.ToString());
                                    } else {
                                        _socket.Send("msg:Could not disconnect from " + connectionId.ToString());
                                    }
                                }
                            }
                            break;
                        case "close":
                            if (Connected) {
                                GlobalObjects.Users.Destroy(this);
                            }
                            break;
                        default:
                            connectionId = GlobalObjects.UserSockets.FindConnectionId(UserModel.UserId);
                            if (!string.IsNullOrEmpty(line.Trim())) {
                                if (connectionId != 0) {
                                    SendDataHelper.Create(new SendDataModel() {
                                        ConnectionId = connectionId,
                                        Data = SocketData,
                                        Timestamp = DateTime.Now
                                    });
                                    GlobalObjects.UserSockets.SendData(connectionId, UserModel.UserId, line);
                                } else {
                                    GlobalObjects.Users.SendSocket(UserModel.UserId, "msg:Unknown Command, or to send to user socket, please use the monitor command.");
                                }
                            }
                            break;
                    }
                }
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "_socket_SocketDataArrival");
                }
            }
        }
        /// <summary>
        /// Socket Connected
        /// </summary>
        /// <param name="SocketID"></param>
        private void _socket_SocketConnected(string SocketID) {
            try {
                _socket.Send("msg:Connected to WPSocketServer");
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "_socket_SocketConnected");
                }
            }
        }
        /// <summary>
        /// Could Not Connect
        /// </summary>
        /// <param name="SocketID"></param>
        private void _socket_CouldNotConnect(string SocketID) {
            try {
                Authenticated = false;
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "_socket_CouldNotConnect");
                }
            }
        }
    }
}