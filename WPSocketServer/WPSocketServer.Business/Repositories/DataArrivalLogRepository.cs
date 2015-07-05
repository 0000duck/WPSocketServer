using System;
using TeamNexgen.Data;
using WPSocketServer.Business.Models;
namespace WPSocketServer.Business.Repositories {
    public class DataArrivalLogRepository {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Create(DataArrivalLogModel model) {
            try {
                using (var e = new EntitiesModel()) {
                    var item = new DataArrivalLog();
                    item.Data = model.Data;
                    item.ConnectionId = model.ConnectionId;
                    item.Timestamp = model.Timestamp;
                    e.Add(item);
                    e.SaveChanges();
                    return true;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}