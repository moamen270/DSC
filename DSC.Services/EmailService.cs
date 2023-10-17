using DSC.Services.IServices;
using DSC.Services.Setting;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;

namespace DSC.Services
{
    public class EmailService : IEmailService
    {
        private readonly MailSetting _setting;

        public EmailService(IOptions<MailSetting> setting)
        {
            _setting = setting.Value;
        }

        public async Task SendAsync(string mailTo, string subject, string body, IList<IFormFile> attachments = null)
        {
            var builder = new BodyBuilder();
            if (attachments != null)
                AddAttachment(builder, attachments);
            builder.HtmlBody = body;

            var email = BuildEmail(mailTo, subject, builder);

            await StmpStart(email);
        }

        private static void AddAttachment(BodyBuilder builder, IList<IFormFile> attachments)
        {
            byte[] fileBytes;
            foreach (var file in attachments)
            {
                if (file.Length > 0)
                {
                    using var ms = new MemoryStream();
                    file.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }
                else
                {
                    fileBytes = new byte[0];
                }
                builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
            }
        }

        private async Task StmpStart(MimeMessage email)
        {
            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(_setting.Host, _setting.Port, SecureSocketOptions.SslOnConnect);
            await smtp.AuthenticateAsync(_setting.Email, _setting.Password);
            await smtp.SendAsync(email);
            await smtp.DisconnectAsync(true);
        }

        private MimeMessage BuildEmail(string mailTo, string subject, BodyBuilder builder)
        {
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_setting.Email),
                Subject = subject
            };
            email.To.Add(MailboxAddress.Parse(mailTo));
            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress(_setting.DisplayName, _setting.Email));

            return email;
        }
    }
}