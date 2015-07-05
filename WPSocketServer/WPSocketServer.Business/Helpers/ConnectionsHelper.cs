using System;
using WPSocketServer.Business.Models;
using WPSocketServer.Business.Repositories;
namespace WPSocketServer.Business.Helpers {
    public static class ConnectionsHelper {
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Create(ConnectionModel model) {
            try {
                var repo = new ConnectionsRepository();
                return repo.Create(model);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Update(ConnectionModel model) {
            try {
                var repo = new ConnectionsRepository();
                return repo.Update(model);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}