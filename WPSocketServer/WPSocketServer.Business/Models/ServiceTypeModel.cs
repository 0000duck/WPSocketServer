using WPSocketServer.Business.Enums;
namespace WPSocketServer.Business.Models {
    /// <summary>
    /// Service Type Model
    /// </summary>
    public class ServiceTypeModel {
        /// <summary>
        /// Service Type Id
        /// </summary>
        public int ServiceTypeId { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Is Active
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// Service Type
        /// </summary>
        public int ServiceTypeEnumId { get; set; }
    }
}