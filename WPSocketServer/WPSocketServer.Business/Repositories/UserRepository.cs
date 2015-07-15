using System;
using System.Linq;
using TeamNexgen.Data;
using WPSocketServer.Business.Models;
namespace WPSocketServer.Business.Repositories {
    public class UserRepository {
        /// <summary>
        /// Email Verify
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public int EmailVerify(string guid) {
            try {
                using (var e = new EntitiesModel()) {
                    if (e.Users.Where(u => u.RegistrationGuid == guid).Count() != 0) {
                        var user = e.Users.Where(u => u.RegistrationGuid == guid).LastOrDefault();
                        user.EmailVerified = true;
                        user.RegistrationGuid = "";
                        e.SaveChanges();
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
        /// Set Registration Guid
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="registrationGuid"></param>
        /// <returns></returns>
        public bool SetRegistrationGuid(int userId, string registrationGuid) {
            try {
                using (var e = new EntitiesModel()) {
                    if (e.Users.Where(u => u.UserId == userId).Count() != 0) {
                        var item = e.Users.Where(u => u.UserId == userId).LastOrDefault();
                        item.RegistrationGuid = registrationGuid;
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
        /// <summary>
        /// Register
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Register(string emailAddress, string password) {
            try {
                using (var e = new EntitiesModel()) {
                    if (e.Users.Where(u => u.EmailAddress == emailAddress).Count() == 0) {
                        var user = new User();
                        user.EmailAddress = emailAddress;
                        user.Password = password;
                        user.EmailVerified = false;
                        user.IrcHostName = "";
                        user.IrcRealName = "";
                        user.IrcUser = "";
                        user.Nickname = "";
                        user.RegistrationGuid = "";
                        user.IrcServerName = "";
                        e.Add(user);
                        e.SaveChanges();
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
        /// Authenticate
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int Authenticate(string emailAddress, string password) {
            try {
                using (var e = new EntitiesModel()) {
                    if (e.Users.Where(u => u.EmailAddress == emailAddress && u.Password == password && u.EmailVerified).Count() != 0) {
                        var user = e.Users.Where(u => u.EmailAddress == emailAddress && u.Password == password && u.EmailVerified).FirstOrDefault();
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
                            Nickname = user.Nickname,
                            EmailVerified = user.EmailVerified,
                            RegistrationGuid = user.RegistrationGuid
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