using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using RTWErrorNotification.Models;

namespace RTWErrorNotification.Services
{
    public class SendEmail
    {
        public static void SendErrorMail(List<CandidateViewModel> listofErrors)
        {
            // SMTP settings (replace with your SMTP server details)
            string smtpServer = "mail.vitechspark.com";
            int smtpPort = 587; // example port, replace with your SMTP port number
            string smtpUsername = "keerthana@vitechspark.com";
            string smtpPassword = "Keerthi@0502";

            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort)
            {
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = true
            };

            MailAddress from = new MailAddress("keerthana@vitechspark.com", "RTW Integration");
            MailAddress to = new MailAddress("keerthana@vitechspark.com", "Recipient Name");
            MailMessage errorMail = new MailMessage(from, to);

            foreach (var error in listofErrors)
            {
                errorMail.To.Add(new MailAddress(error.Email, error.Name));
                errorMail.Subject = "Errors from Right To Work Integration";
                errorMail.SubjectEncoding = Encoding.UTF8;
                errorMail.Body = $"Error for candidate: {error.Name}<br/><br/>Error Message: {error.ErrorMessage}";
                errorMail.BodyEncoding = Encoding.UTF8;
                errorMail.IsBodyHtml = true;

                smtpClient.Send(errorMail);
            }
        }
    }
}
