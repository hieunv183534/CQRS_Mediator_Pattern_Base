using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace NOM.BACKGROUND.Domain
{
    public class MailHelper : IDisposable
    {
        private SmtpClient smtpClient;

        public MailHelper(IConfiguration _configuration)
        {
            var host = _configuration["Gmail:Host"];
            var port = int.Parse(_configuration["Gmail:Port"]);
            var username = _configuration["Gmail:Username"];
            var password = _configuration["Gmail:Password"];
            var enable = bool.Parse(_configuration["Gmail:SMTP:starttls:enable"]);

            smtpClient = new SmtpClient
            {
                Host = host,
                Port = port,
                EnableSsl = enable,
                Credentials = new NetworkCredential(username, password)
            };
        }

        public void Dispose()
        {
            smtpClient.Dispose();
            smtpClient = null;
        }

        public bool Send(string from, string to, string subject, string content, List<string> attachments)
        {
            try
            {
                var mailMessage = new MailMessage(from, to)
                {
                    Subject = subject,
                    Body = content,
                    IsBodyHtml = false
                };
                if (attachments != null)
                {
                    foreach (var attachment in attachments)
                    {
                        mailMessage.Attachments.Add(new Attachment(attachment));
                    }
                }

                smtpClient.Send(mailMessage);

                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
