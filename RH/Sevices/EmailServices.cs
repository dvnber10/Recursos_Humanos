using RH.Models;
using MailKit.Security;
using MailKit.Search;
using MailKit.Net.Smtp;
using MimeKit.Text;
using MimeKit;

namespace RH.Sevices
{
    public class EmailServices : IEmailServices
    {
        private readonly IConfiguration _config;
        public EmailServices(IConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(EmailDTO request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("Email:UserName").Value));

            // Separar las direcciones de correo destinatarias por comas y agregarlas al campo "To"
            foreach (var destinatario in request.Para.Split(','))
            {
                email.To.Add(MailboxAddress.Parse(destinatario.Trim()));
            }

            email.Subject = request.Asunto;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = request.Contenido,
            };

            using var smtp = new SmtpClient();
            smtp.Connect(
                _config.GetSection("Email:Host").Value,
                Convert.ToInt32(_config.GetSection("Email:Port").Value),
                SecureSocketOptions.StartTls
            );

            smtp.Authenticate(_config.GetSection("Email:UserName").Value, _config.GetSection("Email:PassWord").Value);

            smtp.Send(email);
            smtp.Disconnect(true);
        }

    }
}