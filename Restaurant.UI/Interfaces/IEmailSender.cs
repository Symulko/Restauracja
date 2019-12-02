using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.UI.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(
            string fromEmailAddress,
            string toEmailAddress, 
            string emailSubject, 
            string emailBody,
            string password,
            string host,
            int port
            );
    }
}
