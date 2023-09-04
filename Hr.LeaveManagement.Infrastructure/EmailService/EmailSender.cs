using Hr.LeaveMangement.Application.Contracts.Email;
using Hr.LeaveMangement.Application.Models.Email;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hr.LeaveManagement.Infrastructure.EmailService
{
    public class EmailSender : IEmailService
    {
        private readonly EmailSettings _options;
        public EmailSender(IOptions<EmailSettings> options)
        {
            _options = options.Value;
        }
        public async Task SendEmail(EmailEntity email)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.brevo.com/v3/smtp/email");
                request.Headers.Add("api-key", _options.ApiKey);

                var to = new To
                {
                    email = email.Receipient,
                    name = email.FirstName
                };
                var tos = new List<To>();
                tos.Add(to);
                var requestContent = new BrevoRequest
                {
                    sender = new Sender
                    {
                        name = _options.Name,
                        email = _options.Email
                    },
                    htmlContent = Templates.TemplateBuilder(email.FirstName, email.Body),
                    subject = email.Title,
                    to = tos
                };
                var content = JsonSerializer.Serialize(requestContent);
                request.Content = new StringContent(content);
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
