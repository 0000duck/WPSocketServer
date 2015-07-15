namespace WPSocketServer.Business.Models {
    /// <summary>
    /// Connection Model
    /// </summary>
    public class ConnectionModel {
        /// <summary>
        /// Service Type
        /// </summary>
        public int ServiceTypeId { get; set; }
        /// <summary>
        /// ConnectionId
        /// </summary>
        public int ConnectionId { get; set; }
        /// <summary>
        /// UserId
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// Server
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// Port
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// Connected
        /// </summary>
        public bool Connected { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Monitoring
        /// </summary>
        public bool Monitoring { get; set; }
    }
}