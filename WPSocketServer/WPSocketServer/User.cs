using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPSocket;
namespace WPSocketServer {
    public class User {
        public UserModel UserModel { get; set; }
        /// <summary>
        /// Email Address
        /// </summary>
        //private string EmailAddress { get; set; }
        /// <summary>
        /// Password
        /// </summary>
        //public string Password { get; set; }
        /// <summary>
        /// The string which is unique for each user
        /// </summary>
        public string GuidStr { get; set; }
        /// <summary>
        /// The users socket
        /// </summary>
        private AsyncSocket _socket;
        /// <summary>
        /// Entry point
        /// </summary>
        public User() {
            GuidStr = new System.Guid().ToString();
        }
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
                return true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Socket Disconnected
        /// </summary>
        /// <param name="SocketID"></param>
        private void _socket_SocketDisconnected(string SocketID) {
            try {
            } catch (Exception ex) {
                throw ex;
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
                var splt = SocketData.Split(' ');
                switch (splt[0]) {
                    case "identify":

                        break;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Socket Connected
        /// </summary>
        /// <param name="SocketID"></param>
        private void _socket_SocketConnected(string SocketID) {
            try {
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Could Not Connect
        /// </summary>
        /// <param name="SocketID"></param>
        private void _socket_CouldNotConnect(string SocketID) {
            try {
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
    public class Users {
        private List<User> _users;
        private AsyncServer _server;
        public Users() {
            _users = new List<User>();
            _server.ConnectionAccept += _server_ConnectionAccept;
            _server = new AsyncServer(5999);
            _server.Start();
        }
        private void _server_ConnectionAccept(AsyncSocket tmp_Socket) {
            try {
                var guid = AddUser();
                if (!string.IsNullOrEmpty(guid)) {
                    SetSocket(guid, tmp_Socket);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        public string AddUser() {
            var user = new User();
            _users.Add(user);
            return user.GuidStr;
        }
        public bool SetSocket(string guid, AsyncSocket socket) {
            if (_users.Where(u => u.GuidStr == guid).Count() != 0) {
                var user = _users.Where(u => u.GuidStr == guid).FirstOrDefault();
                user.SetSocket(socket);
                return true;
            } else {
                return false;
            }
        }
    }
}