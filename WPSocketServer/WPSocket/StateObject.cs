using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace WPSocket {
    public class StateObject {
        public Socket WorkSocket = null;
        public int BufferSize = 32767;
        public byte[] Buffer = new byte[32768];
    }
}