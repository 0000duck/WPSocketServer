using System;
using WPSocketServer.Business.Models;
using WPSocketServer.Business.Repositories;
namespace WPSocketServer.Business.Helpers {
    public static class DataArriveLogHelper {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Create(DataArrivalLogModel model) {
            try {
                var repo = new DataArrivalLogRepository();
                return repo.Create(model);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}