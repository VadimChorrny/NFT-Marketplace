using Core.DTOs;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Core.Helpers;
using Newtonsoft.Json.Linq;

namespace Core.Services
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _configuration;
        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(MailDTO mailRequest)
        {
            MailJetSettings settings = _configuration.GetSection("MailJet").Get<MailJetSettings>();

            MailjetClient client = new MailjetClient(settings.ApiKey, settings.ApiSecret);
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
               .Property(Send.FromEmail, "wladnaz@ukr.net")
               .Property(Send.FromName, "Vlad")
               .Property(Send.Subject, mailRequest.Subject)
               //.Property(Send.TextPart, )
               .Property(Send.HtmlPart, mailRequest.HtmlMessage)
               .Property(Send.Recipients, new JArray {
                    new JObject {
                        {"Email", mailRequest.Email}
                    }
               });
            await client.PostAsync(request);
        }

        public Task SendInfoAboutSubscribe(SubscribeDTO request)
        {
            throw new NotImplementedException();
        }

        public Task SendWelcomeEmailAsync(WelcomeMailDTO request)
        {
            throw new NotImplementedException();
        }
    }
}
