using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WPSocketServer.Business.Models {
    public class DataArrivalLogModel {
        /// <summary>
        /// Data Arrival Log Id
        /// </summary>
        public int DataArrivalLogId { get; set; }
        /// <summary>
        /// Connection Id
        /// </summary>
        public int ConnectionId { get; set; }
        /// <summary>
        /// Data
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// Time Stamp
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}