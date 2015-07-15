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
            } catch (Exception ex) {
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
                var splt = SocketData.Split((char)13);
                if (Connected) {
                    foreach (var line in splt) {
                        var pass = false;
                        var connectionId = 0;
                        var userId = 0;
                        var splt2 = line.Split(' ');
                        var logged = SendDataHelper.Create(new SendDataModel() { // Log it
                            ConnectionId = connectionId,
                            Data = line,
                            Timestamp = DateTime.Now
                        });
                        switch (splt2[0]) { // Look at the first word in socketdata
                            case "register": // You can only use this command if you are not yet authenticated
                                if (!Authenticated) { // Check not authenticated
                                    userId = UsersHelper.Register(splt2[1], splt2[2]); // Register
                                    if (userId != 0) { // If the userId returned is not 0
                                        if (EmailHelper.IsValidEmail(splt2[1])) { // Is Valid E-mail
                                            var g = Guid.NewGuid().ToString(); // Get a new Guid
                                            UsersHelper.SetRegistrationGuid(userId, g); // Set Registration Guid
                                            EmailHelper.SendHtmlEmail(splt2[1], "Team Nexgen - New User Registration Verification", "Please <a href='http://team-nexgen.org/Home/EmailVerify?guid=" + g + "'>Click Here to Verify</a><br />&nbsp;<br />Or, copy this guid into your clipboard, and paste it into the e-mail verification area in the app."); // Send Email
                                            _socket.Send("msg:Registration successful, please check your email at " + splt2[1] + " and confirm."); // Send Response
                                            pass = true;
                                        } else {
                                            _socket.Send("msg:E-mail Address invalid."); // Send Error Response
                                            pass = true;
                                        }
                                    } else {
                                        _socket.Send("msg:Registration Failure."); // Send Error Response
                                        pass = true;
                                    }
                                }
                                break;
                            case "emailverify": // You can only use this command if you are not yet authenticated
                                if (!Authenticated) { // Check not authenticated
                                    userId = UsersHelper.EmailVerify(splt2[1]); // Check Verification Guid
                                    if (userId != 0) { // If the userid is not 0
                                        var user = UsersHelper.Get(userId); // Get the user
                                        EmailHelper.SendHtmlEmail(user.EmailAddress, "Team Nexgen - E-mail Verified", "Your E-mail is now verified."); // Send him an E-mail letting him know about his E-mail verification.
                                        _socket.Send("msg:E-mail Verification Successful.");
                                        pass = true;
                                    } else {
                                        _socket.Send("msg:E-mail Verify Failure.");
                                        pass = true;
                                    }
                                }
                                break;
                            case "auth": // You can only use this command if you are not yet authenticated
                                if (!Authenticated) {
                                    userId = UsersHelper.Authenticate(splt2[1], splt2[2]);
                                    if (userId != 0) {
                                        UserModel = UsersHelper.Get(userId);
                                        Authenticated = true;
                                        pass = true; 
                                        _socket.Send("msg:Authentication Success");
                                    } else {
                                        pass = true;
                                        _socket.Send("msg:Authentication Failure; Bad EmailAddress or password.");
                                    }
                                }
                                break;
                            case "list":
                                if (Authenticated) {
                                    if (UserModel.EmailVerified) {
                                        var conn = GlobalObjects.UserSockets.Get(UserModel.UserId);
                                        if (conn.Count() != 0) {
                                            _socket.Send("msg:Begin Connections List");
                                            foreach (var connection in conn) {
                                                _socket.Send("con:" + connection.Model.ConnectionId.ToString() + ";" + connection.Model.Connected.ToString() + ":" + connection.Model.Description + ";" + connection.Model.Server + ";" + connection.Model.Port.ToString());
                                            }
                                            _socket.Send("msg:End Connections List");
                                            pass = true;
                                        } else {
                                            _socket.Send("msg:0 Connections");
                                            pass = true;
                                        }
                                    } else {
                                        _socket.Send("msg:Email not verified.");
                                        pass = true;
                                    }
                                } else {
                                    _socket.Send("msg:Must authenticate first.");
                                    pass = true;
                                }
                                break;
                            case "stopmonitoring":
                                if (Authenticated) {
                                    if (int.TryParse(splt2[1], out connectionId)) {
                                        if (UserModel.EmailVerified) {
                                            if (GlobalObjects.UserSockets.StopMonitoring(connectionId, UserModel.UserId)) {
                                                _socket.Send("msg:Stopped monitoring " + connectionId.ToString());
                                                pass = true;
                                            } else {
                                                _socket.Send("msg:Could not stop monitoring " + connectionId.ToString());
                                                pass = true;
                                            }
                                        } else {
                                            _socket.Send("msg:Email not verified.");
                                            pass = true;
                                        }
                                    }
                                } else {
                                    _socket.Send("msg:Must authenticate first.");
                                    pass = true;
                                }
                                break;
                            case "monitor":
                                if (Authenticated) {
                                    if (int.TryParse(splt2[1], out connectionId)) {
                                        if (UserModel.EmailVerified) {
                                            if (GlobalObjects.UserSockets.Monitor(connectionId, UserModel.UserId)) {
                                                _socket.Send("msg:Now monitoring " + connectionId.ToString());
                                                pass = true;
                                            } else {
                                                _socket.Send("msg:Could not monitor " + connectionId.ToString());
                                                pass = true;
                                            }
                                        } else {
                                            _socket.Send("msg:Email not verified.");
                                            pass = true;
                                        }
                                    }
                                } else {
                                    _socket.Send("msg:Must authenticate first.");
                                    pass = true;
                                }
                                break;
                            case "create": // Create a connection to a server
                                if (Authenticated) {
                                    if (UserModel.EmailVerified) {
                                        var server = splt2[1];
                                        var port = int.Parse(splt2[2]);
                                        var serviceType = int.Parse(splt2[3]);
                                        if (!string.IsNullOrEmpty(server)) {
                                            if (port != 0) {
                                                connectionId = GlobalObjects.UserSockets.Create("", UserModel.UserId, server, port, serviceType);
                                                if (connectionId != 0) {
                                                    _socket.Send("msg:Created " + connectionId.ToString());
                                                    pass = true;
                                                } else {
                                                    _socket.Send("msg:Could not create " + connectionId.ToString());
                                                    pass = true;
                                                }
                                            } else {
                                                _socket.Send("msg:Port cannot be 0." + connectionId.ToString());
                                                pass = true;
                                            }
                                        } else {
                                            _socket.Send("msg:Server cannot be empty." + connectionId.ToString());
                                            pass = true;
                                        }
                                    } else {
                                        _socket.Send("msg:Email not verified.");
                                        pass = true;
                                    }
                                } else {
                                    _socket.Send("msg:Must authenticate first.");
                                    pass = true;
                                }
                                break;
                            case "connect":
                                if (Authenticated) {
                                    if (int.TryParse(splt2[1], out connectionId)) {
                                        if (UserModel.EmailVerified) {
                                            if (GlobalObjects.UserSockets.Connect(connectionId, UserModel.UserId)) {
                                                _socket.Send("msg:Connecting to " + connectionId.ToString());
                                                pass = true;
                                            } else {
                                                _socket.Send("msg:Could not Connect to " + connectionId.ToString());
                                                pass = true;
                                            }
                                        } else {
                                            _socket.Send("msg:Email not verified.");
                                            pass = true;
                                        }
                                    }
                                } else {
                                    _socket.Send("msg:Must authenticate first.");
                                    pass = true;
                                }
                                break;
                            case "destroy":
                                if (Authenticated) {
                                    if (int.TryParse(splt2[1], out connectionId)) {
                                        if (UserModel.EmailVerified) {
                                            if (GlobalObjects.UserSockets.Destroy(connectionId, UserModel.UserId)) {
                                                _socket.Send("msg:Destroyed " + connectionId.ToString());
                                                pass = true;
                                            } else {
                                                _socket.Send("msg:Could not Destroy " + connectionId.ToString());
                                                pass = true;
                                            }
                                        } else {
                                            _socket.Send("msg:Email not verified.");
                                            pass = true;
                                        }
                                    }
                                } else {
                                    _socket.Send("msg:Must authenticate first.");
                                    pass = true;
                                }
                                break;
                            case "disconnect":
                                if (Authenticated) {
                                    if (int.TryParse(splt2[1], out connectionId)) {
                                        if (UserModel.EmailVerified) {
                                            if (GlobalObjects.UserSockets.Disconnect(connectionId, UserModel.UserId)) {
                                                _socket.Send("msg:Disconnected from " + connectionId.ToString());
                                                pass = true;
                                            } else {
                                                _socket.Send("msg:Could not disconnect from " + connectionId.ToString());
                                                pass = true;
                                            }
                                        } else {
                                            _socket.Send("msg:Email not verified.");
                                            pass = true;
                                        }
                                    }
                                } else {
                                    _socket.Send("msg:Must authenticate first.");
                                    pass = true;
                                }
                                break;
                            case "close":
                                GlobalObjects.Users.Destroy(this);
                                pass = true;
                                break;
                            default:
                                break;
                        }
                        if (!pass) { // Check to see if they already get a pass
                            if (Authenticated) { // Check Authenticated
                                if (UserModel.EmailVerified) { // Check E-mail Verified
                                    connectionId = GlobalObjects.UserSockets.FindConnectionId(UserModel.UserId); // Get the ConnectionId
                                    if (!string.IsNullOrEmpty(line.Trim())) {
                                        if (connectionId != 0) {
                                            GlobalObjects.UserSockets.SendData(connectionId, UserModel.UserId, line);
                                        } else {
                                            GlobalObjects.Users.SendSocket(UserModel.UserId, "msg:Unknown Command, or use the monitor command.");
                                        }
                                    }
                                } else {
                                    _socket.Send("msg:Email not verified.");
                                }
                            } else {
                                _socket.Send("msg:Must authenticate first.");
                            }
                        }
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