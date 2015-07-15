using System;
using System.Collections.Generic;
using TeamNexgen.Data;
using WPSocketServer.Business.Models;
namespace WPSocketServer.Business.Repositories {
    public class ServiceTypeRepository {
        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        public List<ServiceTypeModel> GetAll() {
            try {
                var result = new List<ServiceTypeModel>();
                using (var e = new EntitiesModel()) {
                    foreach (var item in e.ServiceTypes) {
                        result.Add(new ServiceTypeModel() {
                            Description = item.Description,
                            IsActive = item.IsActive,
                            ServiceTypeEnumId = item.ServiceTypeEnumId,
                            ServiceTypeId = item.ServiceTypeId
                        });
                    }
                }
                return result;
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="serviceTypeId"></param>
        /// <returns></returns>
        public ServiceTypeModel Get(int serviceTypeId) {
            try {
                using (var e = new EntitiesModel()) {
                    var item = new ServiceTypeModel();
                    return new ServiceTypeModel() {
                        Description = item.Description,
                        IsActive = item.IsActive,
                        ServiceTypeEnumId = item.ServiceTypeEnumId,
                        ServiceTypeId = item.ServiceTypeId
                    };
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}