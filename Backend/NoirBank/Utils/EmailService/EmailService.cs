using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace NoirBank.Utils.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly string _sendGridKey;

        public EmailService(IConfiguration configuration)
        {
            _sendGridKey = configuration.GetSection("SendGrid").GetValue<string>("Key");
        }

        public async Task SendEmailAsync(string email, string subject, string message, string templateId = null) => await ExecuteAsync(_sendGridKey, email, subject, message, templateId);

        public async Task SendEmailAsync(Personalization personalization, string templateId) => await ExecuteAsync(_sendGridKey, personalization, templateId);

        private async Task ExecuteAsync(string apiKey, Personalization personalization, string templateId) => await ExecuteAsync(apiKey, null, null, null, templateId, personalization);

        private async Task ExecuteAsync(string apiKey, string email, string subject, string message, string templateId, Personalization personalization = null)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("kuba.porebski3@gmail.com", "Noir Bank"),
                TemplateId = templateId
            };
            if (personalization == null)
            {
                msg.PlainTextContent = message;
                msg.HtmlContent = message;
                msg.AddTo(new EmailAddress(email));
                msg.Subject = subject;
            }
            else
            {
                var personalizations = new List<Personalization>
                {
                personalization
                };

                msg.Personalizations = personalizations;
            }
            msg.SetClickTracking(true, false);

            await client.SendEmailAsync(msg);
        }
    }
}

