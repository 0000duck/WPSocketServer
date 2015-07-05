using System;
namespace WPSocketServer.Business.Models {
    public class SendDataModel {
        /// <summary>
        /// Send Data Id
        /// </summary>
        public int SendDataId { get; set; }
        /// <summary>
        /// Connection Id
        /// </summary>
        public int ConnectionId { get; set; }
        /// <summary>
        /// Data
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// Time stamp
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}