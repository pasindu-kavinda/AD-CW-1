using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AD_CW_1.Helpers
{
    class EmailHelper
    {
        public static void SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                string fromEmail = Env.fromEmail;
                string smtpKey = Env.smtpKey;
                string smtpHost = Env.smtpHost;
                int smtpPort = Env.smtpPort;

                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false
                };
                mail.To.Add(toEmail);

                SmtpClient smtpClient = new SmtpClient(smtpHost)
                {
                    Port = smtpPort,
                    Credentials = new System.Net.NetworkCredential(fromEmail, smtpKey),
                    EnableSsl = true
                };

                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to send email: {ex.Message}");
            }
        }
    }
}
