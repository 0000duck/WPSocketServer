using System;
using WPSocketServer.Business.Models;
using WPSocketServer.Business.Repositories;
namespace WPSocketServer.Business.Helpers {
    public static class UsersHelper {
        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int Authenticate(string emailAddress, string password) {
            try {
                var repo = new UserRepository();
                return repo.Authenticate(emailAddress, password);
            } catch (Exception ex) {
                throw ex;
            }
        }
        public static UserModel Get(int userId) {
            try {
                var repo = new UserRepository();
                return repo.Get(userId);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}