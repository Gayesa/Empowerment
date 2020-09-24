using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empowerment.Web.Helpers
{
    public interface IEmailSenderHelper
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
