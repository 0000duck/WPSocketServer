//nexIRC 3.0.31
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace WPSocket {
    public class AsyncServer {
        public event ConnectionAcceptEventHandler ConnectionAccept;
        public delegate void ConnectionAcceptEventHandler(AsyncSocket tmp_Socket);
        private bool _closed;
        private int _socketPort;
        public AsyncServer(int port) {
            try {
                _socketPort = port;
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Start() {
            try {
                var listenIP = IPAddress.Any;
                var listenPort = _socketPort;
                var listenEp = new IPEndPoint(listenIP, listenPort);
                if (_closed == true) {
                    _closed = false;
                    return;
                }
                var obj_Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                obj_Socket.Bind(listenEp);
                obj_Socket.Listen(100);
                obj_Socket.BeginAccept(new AsyncCallback(onIncomingConnection), obj_Socket);
            } catch (Exception ex) {
                throw ex;
            }
        }
        public void Close() {
            try {
                _closed = true;
            } catch (Exception ex) {
                throw ex;
            }
        }
        private void onIncomingConnection(IAsyncResult result) {
            try {
                var obj_Socket = (Socket)result.AsyncState;
                var obj_Connected = obj_Socket.EndAccept(result);
                if ((_closed == true)) {
                    obj_Connected.Shutdown(SocketShutdown.Both);
                    obj_Connected.Close();
                } else {
                    if (ConnectionAccept != null) {
                        ConnectionAccept(new AsyncSocket(obj_Connected, System.Guid.NewGuid().ToString()));
                    }
                }
                obj_Socket.BeginAccept(new AsyncCallback(onIncomingConnection), obj_Socket);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
