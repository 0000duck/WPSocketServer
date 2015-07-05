/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPSocket {
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
        public event DataArrivalEventHandler DataArrival;
        public delegate void DataArrivalEventHandler(string data);
        private AsyncSocket withEventsField_socket;
        private delegate void StringDelegate(string data);
        private delegate void IntegerDelegate(int @int);
        private delegate void DataArrivalDelegate(int id, string data);
        private delegate void DisconnectDelegate(int id, bool closeSocket);
        private SocketType _socketType = SocketType.Status;
        public enum SocketType {
            Status = 1,
            Ident = 2
        }
        public SocketType SetSocketType {
            set {
                _socketType = value;
            }
        }
        public void CouldNotConnect(string data) {
            //lStrings.ProcessReplaceString(statusId, eStringTypes.sCOULD_NOT_CONNECT, lStatus.ServerDescription(statusId));
        }
        private void socket_CouldNotConnect(string SocketID) {
            StringDelegate couldNotConnectEvent = new StringDelegate(CouldNotConnect);
            this.Invoke(couldNotConnectEvent, SocketID);
        }
        public bool Connected() {
            return socket.Connected;
        }
        public string ReturnLocalIp() {
            string functionReturnValue = null;
            functionReturnValue = socket.ReturnLocalIp();
            return functionReturnValue;
        }
        public long ReturnLocalPort() {
            if ((Connected() == true)) {
                return socket.ReturnLocalPort();
            }
            return 0;
        }
        public void NewSocket(int id, Form form) {
            socket = new AsyncSocket();
            //statusId = id;
            //_invoke = new Form();
            //_invoke = form;
        }
        public void SendSocket(string data) {
            if ((Connected() == true))
                socket.Send(data + Environment.NewLine);
        }
        public void CloseSocket() {
            if (Connected() == true)
                socket.Close();
        }
        public void ConnectSocket(string ip, long port) {
            if (Connected() == false)
                socket.Connect(ip, port);
        }
        private void lSocket_socketConnected(string socketID) {
            //IntegerDelegate connectEvent = new IntegerDelegate(lStatus.ConnectEvent);
            //this.Invoke(connectEvent, 0);
        }
        public void DataArrivalProc(int id, string data) {
            if (DataArrival != null) {
                DataArrival(data);
            }
        }
        private void lSocket_socketDataArrival(string socketID, string socketData, byte[] bytes, int lByteRead) {
            // DO SOMETHING WITH SOCKETDATA
        }
        private void socket_socketDisconnected(string socketId) {
            //DisconnectDelegate disconnectEvent = new DisconnectDelegate(lStatus.CloseStatusConnection);
            //if (Connected() == true)
            //this.Invoke(disconnectEvent, 0, false);
        }

}
*/