using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopStore.Repositories
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(string toEmail, string subject, string message, bool isMessageHtml = false);
    }
}
