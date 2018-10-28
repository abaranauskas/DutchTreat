using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DutchTreat.Services
{
    public class NullMaillService : IMailService
    {
        private ILogger<NullMaillService> _logger;

        public NullMaillService(ILogger<NullMaillService> logger)
        {
            _logger = logger;
        }

        public void SendMail(string to, string subject, string from, string message)
        {
            //log message
            _logger.LogInformation($"To: {to} Subject: {subject} From: {from} Message: {message}");
        }
    }
}
