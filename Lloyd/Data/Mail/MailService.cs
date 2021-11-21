using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lloyd.Data.Mail
{
    public class MailService : IMailService
    {
        private readonly MailConfig _options;

        public MailService(IOptions<MailConfig> options)
        {
            _options = options.Value;
        }
        public async Task SendMailAsync(MailRequest mailRequest)
        {

            var MailText = mailRequest.Body;
            var email = new MimeMessage();
            //email.Sender = MailboxAddress.Parse(_options.Mail);
            email.Sender = MailboxAddress.Parse(mailRequest.RecipientMail);
            //email.To.Add(MailboxAddress.Parse(mailRequest.RecipientMail));
            email.To.Add(MailboxAddress.Parse(_options.Mail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = MailText;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.CheckCertificateRevocation = false;

            smtp.Connect(_options.Host, _options.Port, SecureSocketOptions.SslOnConnect);
            smtp.Authenticate(_options.Mail, _options.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }
    }
}
