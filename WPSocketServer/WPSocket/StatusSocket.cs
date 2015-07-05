using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
//nexIRC 3.0.31
//Sunday, Oct 4th, 2014 - guideX
// ERROR: Not supported in C#: OptionDeclaration
//using nexIRC.clsIrcNumerics;
//using nexIRC.Modules;
//using nexIRC.Sockets;

namespace nexIRC.Sockets {
    public class StatusSocket {
        public event DataArrivalEventHandler DataArrival;
        public delegate void DataArrivalEventHandler(string data);
        private AsyncSocket withEventsField_socket;
        private AsyncSocket socket {
            get { return withEventsField_socket; }
            set {
                if (withEventsField_socket != null) {
                    withEventsField_socket.CouldNotConnect -= socket_CouldNotConnect;
                    withEventsField_socket.SocketConnected -= lSocket_socketConnected;
                    withEventsField_socket.SocketDataArrival -= lSocket_socketDataArrival;
                    withEventsField_socket.SocketDisconnected -= socket_socketDisconnected;
                }
                withEventsField_socket = value;
                if (withEventsField_socket != null) {
                    withEventsField_socket.CouldNotConnect += socket_CouldNotConnect;
                    withEventsField_socket.SocketConnected += lSocket_socketConnected;
                    withEventsField_socket.SocketDataArrival += lSocket_socketDataArrival;
                    withEventsField_socket.SocketDisconnected += socket_socketDisconnected;
                }
            }
        }
        private int statusId;
        private delegate void StringDelegate(string data);
        private delegate void IntegerDelegate(int @int);
        private delegate void DataArrivalDelegate(int id, string data);
        private delegate void DisconnectDelegate(int id, bool closeSocket);
        private Form _invoke;

        private SocketType _socketType = SocketType.Status;
        public enum SocketType {
            Status = 1,
            Ident = 2
        }

        public SocketType SetSocketType {
            set {
                try {
                    _socketType = value;
                } catch (Exception ex) {
                    throw ex;
                }
            }
        }

        public AsyncSocket PassSocket {
            set {
                try {
                    _invoke = invokeForm;
                    socket = value;
                } catch (Exception ex) {
                    throw ex;
                }
            }
        }

        public bool Connected() {
            try {
                return socket.Connected;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public string ReturnLocalIp() {
            string functionReturnValue = null;
            try {
                functionReturnValue = socket.ReturnLocalIp();
            } catch (Exception ex) {
                throw ex;
                return null;
            }
            return functionReturnValue;
        }

        public long ReturnLocalPort() {
            try {
                if ((Connected() == true)) {
                    return socket.ReturnLocalPort();
                }
                return 0;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void NewSocket(int id, Form form) {
            try {
                socket = new AsyncSocket();
                statusId = id;
                _invoke = new Form();
                _invoke = form;
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void SendSocket(string data) {
            try {
                if ((Connected() == true))
                    socket.Send(data + Environment.NewLine);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void CloseSocket() {
            try {
                if (Connected() == true)
                    socket.Close();
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void ConnectSocket(string ip, long port) {
            try {
                if (Connected() == false)
                    socket.Connect(ip, port);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void CouldNotConnect(string data) {
            try {
                lStrings.ProcessReplaceString(statusId, eStringTypes.sCOULD_NOT_CONNECT, lStatus.ServerDescription(statusId));
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void socket_CouldNotConnect(string SocketID) {
            try {
                StringDelegate couldNotConnectEvent = new StringDelegate(CouldNotConnect);
                _invoke.Invoke(couldNotConnectEvent, SocketID);
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void lSocket_socketConnected(string socketID) {
            try {
                IntegerDelegate connectEvent = new IntegerDelegate(lStatus.ConnectEvent);
                _invoke.Invoke(connectEvent, statusId);
            } catch (Exception ex) {
                throw ex;
            }
        }

        public void DataArrivalProc(int id, string data) {
            try {
                if (DataArrival != null) {
                    DataArrival(data);
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void lSocket_socketDataArrival(string socketID, string socketData, byte[] bytes, int lByteRead) {
            try {
                switch (_socketType) {
                    case SocketType.Status:
                        DataArrivalDelegate processDataArrival = new DataArrivalDelegate(lProcessNumeric.lIrcNumericHelper.ProcessDataArrival);
                        _invoke.Invoke(processDataArrival, statusId, socketData);
                        break;
                    case SocketType.Ident:
                        DataArrivalDelegate processDataArrival = new DataArrivalDelegate(DataArrivalProc);
                        _invoke.Invoke(processDataArrival, statusId, socketData);
                        break;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }

        private void socket_socketDisconnected(string socketId) {
            try {
                DisconnectDelegate disconnectEvent = new DisconnectDelegate(lStatus.CloseStatusConnection);
                if (Connected() == true)
                    _invoke.Invoke(disconnectEvent, statusId, false);
            } catch (Exception ex) {
                //Throw ex
            }
        }
    }
}
