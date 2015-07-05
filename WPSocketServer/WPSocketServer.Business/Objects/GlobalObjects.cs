using System;
namespace WPSocketServer.Business.Objects {
    public static class GlobalObjects {
        public static void EntryPoint() {
            // Do Nothing
        }
        /// <summary>
        /// User Sockets
        /// </summary>
        public static UserSockets UserSockets = new UserSockets();
        /// <summary>
        /// Users
        /// </summary>
        public static UsersObject Users = new UsersObject();
        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static UserObject GetUser(int index) {
            try {
                return Users.GetUser(index);
            } catch {
                return null;
            }
        }
    }
}