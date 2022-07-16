using System;
using System.Collections.Generic;
using System.Linq;
using MimeKit;

namespace IdentityProvider.Models
{
    public class MessageModel
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }

        public MessageModel(IEnumerable<string> to, string subject, string content, object p)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(x)));
            Subject = subject;
            Content = content;
        }
    }
}
