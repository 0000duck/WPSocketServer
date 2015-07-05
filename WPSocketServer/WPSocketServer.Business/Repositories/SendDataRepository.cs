using System;
using TeamNexgen.Data;
using WPSocketServer.Business.Models;
namespace WPSocketServer.Business.Repositories {
    public class SendDataRepository {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Create(SendDataModel model) {
            try {
                using (var e = new EntitiesModel()) {
                    var item = new SendData();
                    item.ConnectionId = model.ConnectionId;
                    item.Data = model.Data;
                    item.Timestamp = model.Timestamp;
                    return true;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}
