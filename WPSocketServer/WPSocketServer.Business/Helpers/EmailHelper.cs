using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
namespace WPSocketServer.Business.Helpers {
    public static class EmailHelper {
        public static bool IsValidEmail(string email) {
            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            } catch {
                return false;
            }
        }
        /// <summary>
        /// Send Html Email
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public static void SendHtmlEmail(string to, string subject, string body) {
            try {
                var message = new MailMessage();
                var client = new SmtpClient();
                message.From = new MailAddress(ConfigurationManager.AppSettings["FromEmail"]);
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = true;
                message.Priority = MailPriority.Normal;
                client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["FromEmailPassword"]);
                client.Host = ConfigurationManager.AppSettings["SmtpServer"];
                client.Port = 25;
                client.EnableSsl = false;
                client.Send(message);
            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}