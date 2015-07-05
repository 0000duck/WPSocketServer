using System;
using WPSocketServer.Business.Models;
using WPSocketServer.Business.Repositories;
namespace WPSocketServer.Business.Helpers {
    public static class SendDataHelper {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Create(SendDataModel model) {
            try {
                var repo = new SendDataRepository();
                return repo.Create(model);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}