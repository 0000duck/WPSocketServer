using System;
using System.Collections.Generic;
using WPSocketServer.Business.Models;
using WPSocketServer.Business.Repositories;
namespace WPSocketServer.Business.Helpers {
    public static class ServiceTypeHelper {
        public static List<ServiceTypeModel> GetAll() {
            try {
                var repo = new ServiceTypeRepository();
                return repo.GetAll();
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}