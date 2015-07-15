using System;
using WPSocketServer.Business.Models;
using WPSocketServer.Business.Repositories;
namespace WPSocketServer.Business.Helpers {
    public static class UsersHelper {
        public static int EmailVerify(string guid) {
            try {
                var repo = new UserRepository();
                return repo.EmailVerify(guid);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Set Registration Guid
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="guid"></param>
        /// <returns></returns>
        public static bool SetRegistrationGuid(int userId, string guid) {
            try {
                var repo = new UserRepository();
                return repo.SetRegistrationGuid(userId, guid);
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static int Register(string emailAddress, string password) {
            try {
                var repo = new UserRepository();
                return repo.Register(emailAddress, password);
            } catch (Exception ex) {
                throw ex;
            }
        }
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
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
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