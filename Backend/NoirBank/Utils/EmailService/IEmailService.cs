using System;
using SendGrid.Helpers.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace NoirBank.Utils.EmailService
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message, string templateId = null);

        Task SendEmailAsync(Personalization personalization, string templateId);
    }
}

