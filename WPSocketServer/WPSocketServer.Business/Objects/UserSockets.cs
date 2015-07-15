using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPSocketServer.Business.Enums;
using WPSocketServer.Business.Helpers;
using WPSocketServer.Business.Models;
namespace WPSocketServer.Business.Objects {
    /// <summary>
    /// User Sockets
    /// </summary>
    public class UserSockets {
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
        /// User Sockets
        /// </summary>
        private List<UserSocket> _userSockets;
        /// <summary>
        /// Entry Point
        /// </summary>
        public UserSockets() {
            try {
                _userSockets = new List<UserSocket>();
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Find
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<UserSocket> Get(int userId) {
            try {
                return _userSockets.Where(us => us.Model.UserId == userId).ToList();
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "Get");
                }
                return null;
            }
        }
        /// <summary>
        /// Find ConnectionId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int FindConnectionId(int userId) {
            try {
                if (_userSockets.Where(us => us.Model.UserId == userId && us.Model.Monitoring).Count() != 0) {
                    var socket = _userSockets.Where(us => us.Model.UserId == userId && us.Model.Monitoring).LastOrDefault();
                    if (socket != null) {
                        return socket.Model.ConnectionId;
                    } else {
                        return 0;
                    }
                } else {
                    return 0;
                }
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "FindConnectionId");
                }
                return 0;
            }
        }
        /// <summary>
        /// Send Data
        /// </summary>
        /// <param name="connectionId"></param>
        /// <param name="data"></param>
        public bool SendData(int connectionId, int sourceUserId, string data) {
            try {
                if (_userSockets.Where(us => us.Model.ConnectionId == connectionId && us.Model.UserId == sourceUserId).Count() != 0) {
                    var item = _userSockets.Where(us => us.Model.ConnectionId == connectionId && us.Model.UserId == sourceUserId).FirstOrDefault();
                    item.Socket.Send(data);
                    return true;
                }
                return false;
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "SendData");
                }
                return false;
            }
        }
        /// <summary>
        /// Disconnect
        /// </summary>
        public bool Disconnect(int connectionId, int sourceUserId) {
            try {
                if (_userSockets.Where(s => s.Model.ConnectionId == connectionId && s.Model.UserId == sourceUserId).Count() != 0) {
                    var socket = _userSockets.Where(s => s.Model.ConnectionId == connectionId && s.Model.UserId == sourceUserId).FirstOrDefault();
                    socket.Disconnect();
                    return true;
                }
                return false;
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "Disconnect");
                }
                return false;
            }
        }
        /// <summary>
        /// Destroy Connection
        /// </summary>
        /// <param name="connectionId"></param>
        public bool Destroy(int connectionId, int sourceUserId) {
            try {
                if (_userSockets.Where(s => s.Model.ConnectionId == connectionId && s.Model.UserId == sourceUserId).Count() != 0) {
                    var socket = _userSockets.Where(s => s.Model.ConnectionId == connectionId && s.Model.UserId == sourceUserId).FirstOrDefault();
                    _userSockets.Remove(socket);
                    return true;
                }
                return false;
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "Destroy");
                }
                return false;
            }
        }
        /// <summary>
        /// Monitor Connection
        /// </summary>
        /// <param name="connectionId"></param>
        public bool Monitor(int connectionId, int sourceUserId) {
            try {
                if (_userSockets.Where(s => s.Model.ConnectionId == connectionId && !s.Model.Monitoring && s.Model.UserId == sourceUserId).Count() != 0) {
                    var socket = _userSockets.Where(s => s.Model.ConnectionId == connectionId && !s.Model.Monitoring && s.Model.UserId == sourceUserId).FirstOrDefault();
                    socket.Model.Monitoring = true;
                    ConnectionsHelper.Update(socket.Model);
                    return true;
                }
                return false;
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "Monitor");
                }
                return false;
            }
        }
        /// <summary>
        /// Stop Monitoring
        /// </summary>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public bool StopMonitoring(int connectionId, int sourceUserId) {
            try {
                if (_userSockets.Where(us => us.Model.ConnectionId == connectionId && us.Model.Monitoring && us.Model.UserId == sourceUserId).Count() != 0) {
                    var item = _userSockets.Where(us => us.Model.ConnectionId == connectionId && us.Model.Monitoring && us.Model.UserId == sourceUserId).FirstOrDefault();
                    item.Model.Monitoring = false;
                    return true;
                } else {
                    return false;
                }
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "StopMonitoring");
                }
                return false;
            }
        }
        /// <summary>
        /// Connect
        /// </summary>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public bool Connect(int connectionId, int sourceUserId) {
            try {
                if (_userSockets.Where(s => s.Model.ConnectionId == connectionId && s.Model.UserId == sourceUserId).Count() != 0) {
                    var socket = _userSockets.Where(s => s.Model.ConnectionId == connectionId && s.Model.UserId == sourceUserId).FirstOrDefault();
                    socket.Connect();
                    return true;
                }
                return false;
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "Connect");
                }
                return false;
            }
        }
        /// <summary>
        /// Count
        /// </summary>
        /// <returns></returns>
        public int Count() {
            try {
                return _userSockets.Count();
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "Count");
                }
                return 0;
            }
        }
        /// <summary>
        /// Stop Monitoring
        /// </summary>
        /// <param name="userId"></param>
        public void StopMonitoringAll(int userId) {
            try {
                foreach (var item in _userSockets.Where(u => u.Model.UserId == userId)) {
                    item.Model.Monitoring = false;
                    ConnectionsHelper.Update(item.Model);
                }
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "StopMonitoringAll");
                }
            }
        }
        /// <summary>
        /// Create User Socket
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int Create(string description, int userId, string serverIp, int port, int serviceTypeId) {
            try {
                var connectionId = ConnectionsHelper.Create(new Models.ConnectionModel() {
                    Connected = false,
                    Description = description,
                    Monitoring = false,
                    Port = port,
                    Server = serverIp,
                    UserId = userId,
                    ServiceTypeId = serviceTypeId
                });
                var s = new UserSocket(userId, description, serverIp, port, connectionId);
                _userSockets.Add(s);
                return s.Model.ConnectionId;
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "Create");
                }
                return 0;
            }
        }
    }
}