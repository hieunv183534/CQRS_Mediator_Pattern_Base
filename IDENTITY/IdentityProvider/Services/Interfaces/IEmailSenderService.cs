using System;
using System.Threading.Tasks;
using IdentityProvider.Models;

namespace IdentityProvider.Interfaces
{
    public interface IEmailSenderService
    {
        void SendEmail(MessageModel message);
        Task SendEmailAsync(MessageModel message);
    }
}
