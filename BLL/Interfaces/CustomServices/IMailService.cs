using Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailDTO mailRequest);

        Task SendInfoAboutSubscribe(SubscribeDTO request);

        Task SendWelcomeEmailAsync(WelcomeMailDTO request);
    }
}
