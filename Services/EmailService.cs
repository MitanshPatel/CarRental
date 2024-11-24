using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CarRental.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string message);
    }

    public class EmailService : IEmailService
    {
        private readonly string _apiKey;
        private readonly ILogger<EmailService> _logger;

        public EmailService(string apiKey, ILogger<EmailService> logger)
        {
            _apiKey = apiKey;
            _logger = logger;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            var client = new SendGridClient(_apiKey);
            var from = new EmailAddress("mitanshpatel288@gmail.com", "Car Rental");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, message, message);

            try
            {
                var response = await client.SendEmailAsync(msg);
                _logger.LogInformation($"Email sent to {toEmail} with status code {response.StatusCode}");

                if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Accepted)
                {
                    var responseBody = await response.Body.ReadAsStringAsync();
                    _logger.LogError($"Failed to send email. Status Code: {response.StatusCode}, Response Body: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email");
            }
        }
    }
}
