using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Email_Service.Models;
using Email_Service.Services;
using Newtonsoft.Json;

namespace Email_Service.Messaging
{
    public class AzureMessageBusEndUser : IAzureMessageBusEndUser
    {
        private readonly IConfiguration _config;
        private readonly string ConnectionString;
        private readonly string QueueName;
        private readonly ServiceBusProcessor _regProcessor;
        private readonly EmailSendService _emailService;
        private readonly EmailService _saveToDb;
        public AzureMessageBusEndUser(IConfiguration config, EmailService service)
        {
            _config = config;
            ConnectionString = _config.GetSection("ServiceBus:ConnectionString").Get<string>();
            QueueName = _config.GetSection("QueuesandTopics:RegisterUser").Get<string>();

            var serviceBusClient = new ServiceBusClient(ConnectionString);
            _regProcessor = serviceBusClient.CreateProcessor(QueueName);
            _emailService = new EmailSendService(_config);
            _saveToDb = service;
        }

        public async Task Start()
        {
            _regProcessor.ProcessMessageAsync += OnRegistartion;
            _regProcessor.ProcessErrorAsync += ErrorHandler;
            await _regProcessor.StartProcessingAsync();

        }
        public async Task Stop()
        {
            await _regProcessor.StopProcessingAsync();
            await _regProcessor.DisposeAsync();
        }

        private Task ErrorHandler(ProcessErrorEventArgs args)
        {
            throw new NotImplementedException();
        }

        private async Task OnRegistartion(ProcessMessageEventArgs args)
        {
            var message = args.Message;

            var body = Encoding.UTF8.GetString(message.Body);

            var userMessage = JsonConvert.DeserializeObject<UserMessage>(body);

            //TODO send An Email
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("Experince Diverse Social Life");
                stringBuilder.Append("<h1> Hello " + userMessage.Name + "</h1>");
                stringBuilder.AppendLine("<br/>Welcome to The Social App ");

                stringBuilder.Append("<br/>");
                stringBuilder.Append('\n');
                stringBuilder.Append("<p> Socialize Without Limits</p>");
                var emailLogger = new EmailLoggers()
                {
                    Email = userMessage.Email,
                    Message = stringBuilder.ToString()

                };
                await _saveToDb.SaveData(emailLogger);
                await _emailService.SendEmail(userMessage, stringBuilder.ToString());
                //you can delete the message from the queue
                await args.CompleteMessageAsync(message);
            }
            catch (Exception ex) { }
        }
    }
}