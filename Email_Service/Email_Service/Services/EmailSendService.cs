using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Email_Service.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace Email_Service.Services
{
    public class EmailSendService
    {
        private readonly string email;
        private readonly string password;
        public EmailSendService(IConfiguration _configuration)
        {

            email = _configuration.GetSection("EmailService:Email").Get<string>();
            password = _configuration.GetSection("EmailService:Password").Get<string>();
        }

        public async Task SendEmail(UserMessage res, string message)
        {
            MimeMessage message1 = new MimeMessage();
            message1.From.Add(new MailboxAddress("The Social App ", "wesleykirui@gmail.com"));

            // Set the recipient's email address
            message1.To.Add(new MailboxAddress(res.Name, res.Email));

            message1.Subject = "Welcome to The Social App";

            var body = new TextPart("html")
            {
                Text = message.ToString()
            };
            message1.Body = body;

            var client = new SmtpClient();

            client.Connect("smtp.gmail.com", 587, false);

            client.Authenticate("wesleykirui2021@gmail.com", "wcyb wdfc jaou pyql");

            await client.SendAsync(message1);

            await client.DisconnectAsync(true);
        }
    }
}