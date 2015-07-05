using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace nexIRC.Sockets {
    public class Identd {
        private AsyncServer withEventsField__listenSocket;
        private AsyncServer _listenSocket {
	        get { return withEventsField__listenSocket; }
	        set {
		        try {
                    if (withEventsField__listenSocket != null) {
			            withEventsField__listenSocket.ConnectionAccept -= _listenSocket_ConnectionAccept;
		            }
		            withEventsField__listenSocket = value;
		            if (withEventsField__listenSocket != null) {
			            withEventsField__listenSocket.ConnectionAccept += _listenSocket_ConnectionAccept;
		            }
                } catch(Exception ex) {
                    throw ex;
                }
	        }
        }
        private StatusSocket withEventsField__clientSocket;
        private StatusSocket _clientSocket {
	        get { return withEventsField__clientSocket; }
	        set {
		        if (withEventsField__clientSocket != null) {
			        withEventsField__clientSocket.DataArrival -= _clientSocket_DataArrival;
		        }
		        withEventsField__clientSocket = value;
		        if (withEventsField__clientSocket != null) {
			        withEventsField__clientSocket.DataArrival += _clientSocket_DataArrival;
		        }
	        }
        }
        private delegate void StringDelegate(string lData);
        private delegate void IntegerDelegate(int @int);
        private delegate void DataArrivalDelegate(int id, string data);
        public void Listen(long port = 0) {
	        try {
		        _listenSocket = new AsyncServer(Convert.ToInt32(port));
		        _listenSocket.Start();
	        } catch (Exception ex) {
		        throw ex;
	        }
        }
        private void _listenSocket_ConnectionAccept(AsyncSocket tempSocket) {
	        try {
		        _clientSocket.PassSocket(lStatus.GetObject(lStatus.ActiveIndex).sWindow) = tempSocket;
	        } catch (Exception ex) {
		        throw ex;
	        }
        }
        public void ProcessSocketDataArrival(int socketId) {
	        string msg = null;
	        string msg2 = null;
	        frmStatus form = default(frmStatus);
            //FIX!
	        try {
		        form = lStatus.GetObject(lStatus.ActiveIndex).sWindow;
		        msg = Strings.Trim(lStatus.StatusSocketLocalPort(socketId).ToString()) + ", " + Strings.Trim(lStatus.ReturnRemotePort(lStatus.ActiveIndex).ToString()) + " : USERID : " + lSettings.lIRC.iIdent.iUserID;
		        msg2 = Strings.Trim(lStatus.StatusSocketLocalPort(lStatus.ActiveIndex).ToString()) + ", " + Strings.Trim(lStatus.ReturnRemotePort(lStatus.ActiveIndex).ToString()) + " : SYSTEM : " + lSettings.lIRC.iIdent.iSystem;
		        _clientSocket.SendSocket(msg + Environment.NewLine);
		        _clientSocket.SendSocket(msg2 + Environment.NewLine);
		        _clientSocket.CloseSocket();
	        } catch (Exception ex) {
		        throw ex;
	        }
        }
        public Identd() {
	        try {
		        _clientSocket = new StatusSocket();
		        _clientSocket.SetSocketType = StatusSocket.SocketType.Ident;
	        } catch (Exception ex) {
		        throw ex;
	        }
        }
        private void _clientSocket_DataArrival(string data) {
	        try {
		        var statusId = lStatus.ActiveIndex();
		        IntegerDelegate processSocketDataArrivalProc = new IntegerDelegate(ProcessSocketDataArrival);
		        lStatus.GetObject(statusId).sWindow.Invoke(processSocketDataArrivalProc, statusId);
	        } catch (Exception ex) {
		        throw ex;
	        }
        }

    }
}