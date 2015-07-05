using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace WPSocket {
    public class AsyncSocket {
        /// <summary>
        /// Socket Error
        /// </summary>
        public event SocketErrorEventHandler SocketError;
        public delegate void SocketErrorEventHandler(Exception ex);
        /// <summary>
        /// Socket Disconnected
        /// </summary>
        public event SocketDisconnectedEventHandler SocketDisconnected;
        public delegate void SocketDisconnectedEventHandler(string SocketID);
        /// <summary>
        /// Socket Data Arrival
        /// </summary>
        public event SocketDataArrivalEventHandler SocketDataArrival;
        public delegate void SocketDataArrivalEventHandler(string SocketID, string SocketData, byte[] lBytes, int lBytesRead);
        /// <summary>
        /// Socket Connected
        /// </summary>
        public event SocketConnectedEventHandler SocketConnected;
        public delegate void SocketConnectedEventHandler(string SocketID);
        /// <summary>
        /// Could Not Connect
        /// </summary>
        public event CouldNotConnectEventHandler CouldNotConnect;
        public delegate void CouldNotConnectEventHandler(string SocketID);
        /// <summary>
        /// SocketId
        /// </summary>
        private string _socketId;
        /// <summary>
        /// Temp Socket
        /// </summary>
        private Socket _tempSocket;
        /// <summary>
        /// Entry Point
        /// </summary>
        /// <param name="tmp_Socket"></param>
        /// <param name="tmp_SocketID"></param>
        public AsyncSocket(Socket tmp_Socket, string tmp_SocketID) {
            try {
                _socketId = tmp_SocketID;
                _tempSocket = tmp_Socket;
                var obj_Socket = tmp_Socket;
                var obj_SocketState = new StateObject();
                obj_SocketState.WorkSocket = obj_Socket;
                obj_Socket.BeginReceive(obj_SocketState.Buffer, 0, obj_SocketState.BufferSize, 0, new AsyncCallback(onDataArrival), obj_SocketState);
            } catch (Exception ex) {
                if (SocketError != null) {
                    SocketError(ex);
                }
            }
        }
        /// <summary>
        /// Connected
        /// </summary>
        public bool Connected {
            get {
                try {
                    return (_tempSocket.Connected);
                } catch (Exception ex) {
                    if (SocketError != null) {
                        SocketError(ex);
                    }
                    return false;
                }
            }
        }
        /// <summary>
        /// Async Socket
        /// </summary>
        public AsyncSocket() {
            try {
                _tempSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            } catch (Exception ex) {
                if (SocketError != null) {
                    SocketError(ex);
                }
            }
        }
        /// <summary>
        /// Send Bytes
        /// </summary>
        /// <param name="Buffer"></param>
        public void SendBytes(byte[] Buffer) {
            try {
                var obj_StateObject = new StateObject();
                obj_StateObject.WorkSocket = _tempSocket;
                _tempSocket.BeginSend(Buffer, 0, Buffer.Length, 0, new AsyncCallback(onSendComplete), obj_StateObject);
            } catch (Exception ex) {
                if (SocketError != null) {
                    SocketError(ex);
                }
            }
        }
        /// <summary>
        /// Send
        /// </summary>
        /// <param name="tmp_Data"></param>
        public void Send(string tmp_Data) {
            try {
                var obj_StateObject = new StateObject();
                obj_StateObject.WorkSocket = _tempSocket;
                var Buffer = Encoding.UTF8.GetBytes(tmp_Data);
                _tempSocket.BeginSend(Buffer, 0, Buffer.Length, 0, new AsyncCallback(onSendComplete), obj_StateObject);
            } catch (Exception ex) {
                if (SocketError != null) {
                    SocketError(ex);
                }
            }
        }
        /// <summary>
        /// Close
        /// </summary>
        public void Close() {
            try {
                _tempSocket.Shutdown(SocketShutdown.Both);
                _tempSocket.Close();
            } catch (Exception ex) {
                if (SocketError != null) {
                    SocketError(ex);
                }
            }
        }
        /// <summary>
        /// Connect
        /// </summary>
        /// <param name="hostIP"></param>
        /// <param name="hostPort"></param>
        public void Connect(string hostIP, long hostPort) {
            try {
                var hostEndPoint = new IPEndPoint(Dns.Resolve(hostIP).AddressList[0], Convert.ToInt32(hostPort));
                var obj_Socket = _tempSocket;
                obj_Socket.BeginConnect(hostEndPoint, new AsyncCallback(onConnectionComplete), obj_Socket);
            } catch (Exception ex) {
                if (SocketError != null) {
                    SocketError(ex);
                }
            }
        }
        /// <summary>
        /// On Data Arrival
        /// </summary>
        /// <param name="ar"></param>
        private void onDataArrival(IAsyncResult ar) {
            try {
                var obj_SocketState = (StateObject)ar.AsyncState;
                var obj_Socket = obj_SocketState.WorkSocket;
                string sck_Data = null;
                int BytesRead = obj_Socket.EndReceive(ar);
                if (BytesRead > 0) {
                    sck_Data = Encoding.UTF8.GetString(obj_SocketState.Buffer, 0, BytesRead);
                    if (SocketDataArrival != null) {
                        SocketDataArrival(_socketId, sck_Data, obj_SocketState.Buffer, BytesRead);
                    }
                }
                obj_Socket.BeginReceive(obj_SocketState.Buffer, 0, obj_SocketState.BufferSize, 0, new AsyncCallback(onDataArrival), obj_SocketState);
            } catch (SocketException exx) {
                if (SocketDisconnected != null) {
                    SocketDisconnected(SocketID);
                }
                if (SocketError != null) {
                    SocketError(exx);
                }
            } catch (Exception ex) {
                if (SocketDisconnected != null) {
                    SocketDisconnected(SocketID);
                }
                if ((!ex.Message.Contains("Cannot access a disposed object"))) {
                    if (SocketError != null) {
                        SocketError(ex);
                    }
                }
            }
        }
        public string ReturnLocalIp() {
            try {
                return new WebClient().DownloadString("http://www.whatismyip.com/automation/n09230945.asp");
            } catch (Exception ex) {
                if (SocketError != null) {
                    SocketError(ex);
                }
                return "";
            }
        }
        public long ReturnLocalPort() {
            try {
                return Convert.ToInt64(((IPEndPoint)_tempSocket.LocalEndPoint).Port);
            } catch (Exception ex) {
                if (SocketError != null) {
                    SocketError(ex);
                }
                return 0;
            }
        }
        private void onSendComplete(IAsyncResult ar) {
            try {
                var obj_SocketState = (StateObject)ar.AsyncState;
                var obj_Socket = obj_SocketState.WorkSocket;
            } catch (Exception ex) {
                if (SocketError != null) {
                    SocketError(ex);
                }
            }
        }
        private void onConnectionComplete(IAsyncResult ar) {
            try {
                _tempSocket = (Socket)ar.AsyncState;
                _tempSocket.EndConnect(ar);
                if (SocketConnected != null) {
                    SocketConnected("null");
                }
                var socketState = new StateObject();
                socketState.WorkSocket = _tempSocket;
                _tempSocket.BeginReceive(socketState.Buffer, 0, socketState.BufferSize, 0, new AsyncCallback(onDataArrival), socketState);
            } catch (Exception ex) {
                if ((ex.Message.Contains("A connection attempt failed because the connected party did not properly respond after a period of time, or established connection failed because connected host has failed to respond"))) {
                    if (CouldNotConnect != null) {
                        CouldNotConnect(SocketID);
                    }
                } else {
                    if (SocketError != null) {
                        SocketError(ex);
                    }
                }
            }
        }
        public string SocketID {
            get {
                try {
                    return _socketId;
                } catch (Exception ex) {
                    if (SocketError != null) {
                        SocketError(ex);
                    }
                    return "";
                }
            }
        }
    }
}