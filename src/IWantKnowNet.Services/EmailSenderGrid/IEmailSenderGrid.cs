using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Emails
{
    public interface IEmailSenderGrid
    {
        public Task SendEmailAsync(string toEmail, string subject, string message);
    }
}
