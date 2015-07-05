using System;
using System.Collections.Generic;
using System.Linq;
using TeamNexgen.Data;
using WPSocketServer.Business.Models;
namespace WPSocketServer.Business.Repositories {
    public class ConnectionsRepository {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<ConnectionModel> Get(int userId) {
            try {
                using (var e = new EntitiesModel()) {
                    var connections = e.Connections.Where(c => c.UserId == userId).ToList();
                    var result = new List<ConnectionModel>();
                    foreach (var item in connections) {
                        result.Add(new ConnectionModel() {
                            ConnectionId = item.ConnectionId,
                            Port = item.Port,
                            Server = item.Server,
                            UserId = item.UserId,
                            Connected = item.Connected,
                            Description = item.Description,
                            Monitoring = item.Monitoring,
                            ServiceType = item.ServiceType
                        });
                    }
                    return result;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Create(ConnectionModel model) {
            try {
                using (var e = new EntitiesModel()) {
                    var connection = new Connection();
                    connection.UserId = model.UserId;
                    connection.Server = model.Server;
                    connection.Port = model.Port;
                    connection.Connected = model.Connected;
                    connection.Description = model.Description;
                    connection.Monitoring = model.Monitoring;
                    connection.ServiceType = model.ServiceType;
                    e.Add(connection);
                    e.SaveChanges();
                    return connection.ConnectionId;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(ConnectionModel model) {
            try {
                using (var e = new EntitiesModel()) {
                    if (e.Connections.Where(c => c.ConnectionId == model.ConnectionId).Count() != 0) {
                        var connection = e.Connections.Where(c => c.ConnectionId == model.ConnectionId).FirstOrDefault();
                        connection.Connected = model.Connected;
                        connection.Description = model.Description;
                        connection.Port = model.Port;
                        connection.Server = model.Server;
                        connection.UserId = model.UserId;
                        connection.Monitoring = model.Monitoring;
                        connection.ServiceType = model.ServiceType;
                        e.SaveChanges();
                        return true;
                    } else {
                        return false;
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}