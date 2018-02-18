using System;
using System.Net.Mail;

namespace GunungSteels.Notification
{
    public static class EMail
    {
        public static void SendMail(string fromMailAddress, string toMailAddress, string subject, string body, string ccMailAddress = "")
        {
           
            using (MailMessage mm = new MailMessage(fromMailAddress, toMailAddress))
            {
                if (!String.IsNullOrEmpty(ccMailAddress))
                {
                    foreach (var ccMailId in ccMailAddress.Split(new[] { ';', ',' }))
                    {
                        mm.CC.Add(new MailAddress(ccMailId));
                    }
                }
                mm.Subject = subject;
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = System.Configuration.ConfigurationManager.AppSettings["smtpserver"];
                smtp.Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SmtpPort"]);
                smtp.EnableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["SmtpSslEnabled"]);
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential();
                credentials.UserName = fromMailAddress;
                credentials.Password = System.Configuration.ConfigurationManager.AppSettings["TargetEmailPassword"];
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = credentials;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Port = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SmtpPort"]);

                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
               System.Security.Cryptography.X509Certificates.X509Certificate certificate,
               System.Security.Cryptography.X509Certificates.X509Chain chain,
               System.Net.Security.SslPolicyErrors sslPolicyErrors)
                {
                    return true;
                };

                smtp.Send(mm);
            }
        }
    }
}