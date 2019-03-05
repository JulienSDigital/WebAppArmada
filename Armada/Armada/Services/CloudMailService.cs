using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Armada.Services
{
    public class CloudMailService : IMailService
    {

        //private string _mailTo = Startup.Configuration["mailSettings:mailToAddress"];
        //private string _mailFrom = Startup.Configuration["mailSettings:mailFromAddress"];
        private const string _mailTo = "mailSettings@mailFromAddress.com";
        private const string _mailFrom = "mailSettings@mailFromAddress.com";

        public void Send(string subject, string message)
        {
            // send mail - output to debug window
            Debug.WriteLine($"Mail from {_mailFrom} to {_mailTo}, with CloudMailService.");
            Debug.WriteLine($"Subject: {subject}");
            Debug.WriteLine($"Message: {message}");

        }
    }
}
