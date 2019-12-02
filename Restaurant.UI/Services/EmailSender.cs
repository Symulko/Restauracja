using Restaurant.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.UI.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender()
        {

        }

        public async Task SendEmailAsync(string fromEmailAddress, 
            string toEmailAddress, string emailSubject, 
            string emailBody, string password, string host, int port)
        {
            var fromAddress = new MailAddress(fromEmailAddress, fromEmailAddress);
            var toAddress = new MailAddress(toEmailAddress, toEmailAddress);
            string subject = emailSubject;
            string body = emailBody;

            var smtp = new SmtpClient
            {
                Host = host,
                Port = port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmailAddress, password)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })

            {
                await smtp.SendMailAsync(message);
            }
        }
    }
}
