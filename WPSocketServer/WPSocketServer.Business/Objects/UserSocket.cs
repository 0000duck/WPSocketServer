using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPSocket;
using WPSocketServer.Business.Helpers;
using WPSocketServer.Business.Models;
namespace WPSocketServer.Business.Objects {
    /// <summary>
    /// User Socket
    /// </summary>
    public class UserSocket {
        /// <summary>
        /// Process Error
        /// </summary>
        public event ProcessErrorEventHandler ProcessError;
        /// <summary>
        /// Process Error Event Handler
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="func"></param>
        public delegate void ProcessErrorEventHandler(Exception ex, string func);
        /// <summary>
        /// Connection Model
        /// </summary>
        public ConnectionModel Model { get; set; }
        /// <summary>
        /// Socket
        /// </summary>
        public AsyncSocket Socket { get; set; }
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="serverIp"></param>
        /// <param name="port"></param>
        public UserSocket(int userId, string description, string serverIp, int port, int connectionId) {
            try {
                Model = new ConnectionModel();
                GlobalObjects.UserSockets.StopMonitoringAll(userId);
                Model.Monitoring = false;
                Model.Server = serverIp;
                Model.Port = port;
                Model.UserId = userId;
                Model.Description = description;
                Model.ConnectionId = connectionId;
                Socket = new AsyncSocket();
                Socket.CouldNotConnect += Socket_CouldNotConnect;
                Socket.SocketConnected += Socket_SocketConnected;
                Socket.SocketDataArrival += Socket_SocketDataArrival;
                Socket.SocketDisconnected += Socket_SocketDisconnected;
                Socket.SocketError += Socket_SocketError;
                ConnectionsHelper.Update(Model);
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "UserSocket");
                }
            }
        }
        /// <summary>
        /// Socket Error
        /// </summary>
        /// <param name="_ex"></param>
        private void Socket_SocketError(Exception _ex) {
            try {
                var b = false;
                if (_ex.Message.Contains("An established connection was aborted by the software in your host machine")) {
                    b = true;
                } else if (_ex.Message.Contains("An existing connection was forcibly closed by the remote host")) {
                    b = true;
                }
                if (b) {
                    SocketDisconnected();
                } else {
                    Model.Connected = false;
                    Socket = new AsyncSocket();
                    Socket.CouldNotConnect += Socket_CouldNotConnect;
                    Socket.SocketConnected += Socket_SocketConnected;
                    Socket.SocketDataArrival += Socket_SocketDataArrival;
                    Socket.SocketDisconnected += Socket_SocketDisconnected;
                    Socket.SocketError += Socket_SocketError;
                    ConnectionsHelper.Update(Model);
                }
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "Socket_SocketError");
                }
            }
        }
        /// <summary>
        /// Disconnect
        /// </summary>
        public void Disconnect() {
            try {
                Socket.Close();
                Socket = new AsyncSocket();
                Socket.CouldNotConnect += Socket_CouldNotConnect;
                Socket.SocketConnected += Socket_SocketConnected;
                Socket.SocketDataArrival += Socket_SocketDataArrival;
                Socket.SocketDisconnected += Socket_SocketDisconnected;
                Socket.SocketError += Socket_SocketError;
                ConnectionsHelper.Update(Model);
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "Disconnect");
                }
            }
        }
        /// <summary>
        /// Connect
        /// </summary>
        public void Connect() {
            try {
                Socket.Connect(Model.Server, Model.Port);
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "Connect");
                }
            }
        }
        /// <summary>
        /// Connected?
        /// </summary>
        public bool Connected {
            get {
                try {
                    if (Socket != null) {
                        return Socket.Connected;
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
        /// Socket Disconnected
        /// </summary>
        /// <param name="SocketID"></param>
        private void Socket_SocketDisconnected(string SocketID) {
            try {
                SocketDisconnected();
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "Socket_SocketDisconnected");
                }
            }
        }
        /// <summary>
        /// Socket Disconnected
        /// </summary>
        private void SocketDisconnected() {
            try {
                GlobalObjects.Users.SendSocket(Model.UserId, "msg:Socket_SocketDisconnected:" + Model.ConnectionId.ToString());
                Socket = new AsyncSocket();
                Socket.CouldNotConnect += Socket_CouldNotConnect;
                Socket.SocketConnected += Socket_SocketConnected;
                Socket.SocketDataArrival += Socket_SocketDataArrival;
                Socket.SocketDisconnected += Socket_SocketDisconnected;
                Socket.SocketError += Socket_SocketError;
                Model.Connected = false;
                ConnectionsHelper.Update(Model);
                if (Model.Monitoring) {
                    GlobalObjects.Users.SendSocket(Model.UserId, Model.Server + ":Socket_SocketDisconnected");
                }
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "SocketDisconnected");
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
        private void Socket_SocketDataArrival(string SocketID, string SocketData, byte[] lBytes, int lBytesRead) {
            try {
                Model.Connected = false;
                if (DataArriveLogHelper.Create(new DataArrivalLogModel() {
                    ConnectionId = Model.ConnectionId,
                    Data = SocketData,
                    Timestamp = DateTime.Now
                })) {
                    //if (Model.ServiceType == Enums.ServiceType.IrcClient) {
                    if (SocketData.ToUpper().Contains("PING :")) {
                        if (SocketData.ToUpper().Substring(0, 6) == "PING :") { // Keep alive
                            var splt = SocketData.Split(new string[] { "PING :" }, StringSplitOptions.None);
                            Socket.Send("PONG :" + splt[1] + Environment.NewLine);
                        }
                    }
                    //}
                    if (Model.Monitoring) {
                        GlobalObjects.Users.SendSocket(Model.UserId, SocketData);
                    }
                }
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "Socket_SocketDataArrival");
                }
            }
        }
        /// <summary>
        /// Socket Connected
        /// </summary>
        /// <param name="SocketID"></param>
        private void Socket_SocketConnected(string SocketID) {
            try {
                Model.Connected = true;
                ConnectionsHelper.Update(Model);
                //if (Model.ServiceType == Enums.ServiceType.IrcClient) {
                var user = UsersHelper.Get(Model.UserId);
                Socket.Send("NICK " + user.Nickname + Environment.NewLine);
                System.Threading.Thread.Sleep(200);
                Socket.Send("USER " + user.IrcUser + " " + user.IrcHostName + " " + user.IrcServerName + " :" + user.IrcRealName + Environment.NewLine);
                //}
                if (Model.Monitoring) {
                    GlobalObjects.Users.SendSocket(Model.UserId, Model.Server + ":Socket_SocketConnected");
                }
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "Socket_SocketConnected");
                }
            }
        }
        /// <summary>
        /// Could not connect
        /// </summary>
        /// <param name="SocketID"></param>
        private void Socket_CouldNotConnect(string SocketID) {
            try {
                if (Model.Monitoring) {
                    GlobalObjects.Users.SendSocket(Model.UserId, Model.Server + ":Socket_CouldNotConnect");
                }
                Socket = new AsyncSocket();
                Socket.CouldNotConnect += Socket_CouldNotConnect;
                Socket.SocketConnected += Socket_SocketConnected;
                Socket.SocketDataArrival += Socket_SocketDataArrival;
                Socket.SocketDisconnected += Socket_SocketDisconnected;
                Socket.SocketError += Socket_SocketError;
                Model.Connected = false;
                ConnectionsHelper.Update(Model);
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "Socket_CouldNotConnect");
                }
            }
        }
    }
}