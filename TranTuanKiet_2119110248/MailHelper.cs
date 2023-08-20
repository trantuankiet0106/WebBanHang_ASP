using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace TranTuanKiet_2119110248
{
    public class MailHelper
    {
        public  void SendMail(string subject , string content)
        {
            var FromEmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
            var ToEmailAddress = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
            var FromEmailDisplayName = ConfigurationManager.AppSettings["FromEmailDisplayName"].ToString();
            var FromEmailPassword = ConfigurationManager.AppSettings["FromEmailPassword"].ToString();
            var SmtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var SmtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();

            bool enabledSsl = bool.Parse(ConfigurationManager.AppSettings["EnabledSSL"].ToString());
            string body = content;
            MailMessage message = new MailMessage(new MailAddress(FromEmailAddress, FromEmailDisplayName), new MailAddress(ToEmailAddress));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = body;

            var client = new SmtpClient();
            client.Credentials = new NetworkCredential(FromEmailAddress, FromEmailPassword);
            client.Host = SmtpHost;
            client.EnableSsl = enabledSsl;
            client.Port = !string.IsNullOrEmpty(SmtpPort) ? Convert.ToInt32(SmtpPort) : 0;
            client.Send(message);
           

        }
    }
}