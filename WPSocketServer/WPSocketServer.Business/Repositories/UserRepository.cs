using System;
using System.Linq;
using TeamNexgen.Data;
using WPSocketServer.Business.Models;
namespace WPSocketServer.Business.Repositories {
    public class UserRepository {
        /// <summary>
        /// Authenticate
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Authenticate(string emailAddress, string password) {
            try {
                using (var e = new EntitiesModel()) {
                    if (e.Users.Where(u => u.EmailAddress == emailAddress && u.Password == password).Count() != 0) {
                        var user = e.Users.Where(u => u.EmailAddress == emailAddress && u.Password == password).FirstOrDefault();
                        return user.UserId;
                    } else {
                        return 0;
                    }
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public UserModel Get(int userId) {
            try {
                using (var e = new EntitiesModel()) {
                    if (e.Users.Where(u => u.UserId == userId).Count() != 0) {
                        var user = e.Users.Where(u => u.UserId == userId).FirstOrDefault();
                        return new UserModel() {
                            EmailAddress = user.EmailAddress,
                            IrcHostName = user.IrcHostName,
                            IrcRealName = user.IrcRealName,
                            IrcServerName = user.IrcServerName,
                            IrcUser = user.IrcUser,
                            Password = user.Password,
                            UserId = user.UserId,
                            Nickname = user.Nickname
                        };
                    }
                    return null;
                }
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}