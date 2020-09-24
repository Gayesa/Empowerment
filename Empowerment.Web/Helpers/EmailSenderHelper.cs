using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Empowerment.Web.Models;


namespace Empowerment.Web.Helpers
{
    public class EmailSenderHelper : IEmailSenderHelper
    {
        private SmtpClient Cliente { get; }
        private EmailSenderOptionsModel Options { get; }

        public EmailSenderHelper(IOptions<EmailSenderOptionsModel> options)
        {
            Options = options.Value;
            Cliente = new SmtpClient()
            {
                Host = Options.Host,
                Port = Options.Port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Options.Email, Options.Password),
                EnableSsl = Options.EnableSsl,
            };
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            MailMessage correo = new MailMessage(from: Options.Email, to: email, subject: subject, body: message)
            {
                IsBodyHtml = true
            };
            return Cliente.SendMailAsync(correo);
        }
    }
}
