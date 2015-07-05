using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPSocket;
namespace WPSocketServer.Business.Objects {
    public class UsersObject {
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
        /// List of Users
        /// </summary>
        private List<UserObject> _users;
        /// <summary>
        /// The Server that listens for and accepts incomoing connections
        /// </summary>
        private AsyncServer _server;
        /// <summary>
        /// Entry Point
        /// </summary>
        public UsersObject() {
            try {
                _users = new List<UserObject>(); // Initialise new list of users for in memory operations
                _server = new AsyncServer(5999); // Listen on the port I will alwyas listen on
                _server.ConnectionAccept += _server_ConnectionAccept; // Wire up event
                _server.Start(); // Begin listening for new connections immediately
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "UsersObject");
                }
            }
        }
        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public UserObject GetUser(int index) {
            try {
                return _users[index];
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "GetUser");
                }
                return null;
            }
        }
        /// <summary>
        /// Count
        /// </summary>
        /// <returns></returns>
        public int Count() {
            try {
                return _users.Count();
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "Count");
                }
                return 0;
            }
        }
        /// <summary>
        /// Connection Accept
        /// </summary>
        /// <param name="tmp_Socket"></param>
        private void _server_ConnectionAccept(AsyncSocket tmp_Socket) {
            try {
                var user = new UserObject();
                _users.Add(user);
                user.SetSocket(tmp_Socket);
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "_server_ConnectionAccept");
                }
            }
        }
        /// <summary>
        /// Destroy
        /// </summary>
        /// <param name="obj"></param>
        public void Destroy(UserObject obj) {
            try {
                obj.CloseSocket();
                _users.Remove(obj);
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "Destroy");
                }
            }
        }
        /// <summary>
        /// Send Socket
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="data"></param>
        public void SendSocket(int userId, string data) {
            try {
                var user = _users.Where(u => u.UserModel.UserId == userId).FirstOrDefault();
                if (user != null) {
                    if (user.Connected) {
                        user.SendSocket(data);
                    } else {
                        // TODO: SEND NOTIFICATION SOMETIMES
                        // TODO!
                    }
                }
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "SendSocket");
                }
            }
        }
        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        public List<UserObject> GetAll() {
            try {
                return _users;
            } catch (Exception ex) {
                if (ProcessError != null) {
                    ProcessError(ex, "GetAll");
                }
                return null;
            }
        }
    }
}