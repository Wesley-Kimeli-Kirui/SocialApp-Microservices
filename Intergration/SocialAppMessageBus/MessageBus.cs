using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Intergration;
using Newtonsoft.Json;

namespace SocialAppMessageBus
{
    public class MessageBus : IMessageBus
    {
        public string ConnectionString = "Endpoint=sb://socialappservice.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Qya+c879gkP2IMRkWsv3WTr2jfcdaX8A4+ASbIlQkuI=";

        public async Task PublishMessage(object message, string queue_topic_name)
        {
            var serviceBus = new ServiceBusClient(this.ConnectionString);
            var serviceBusSender = serviceBus.CreateSender(queue_topic_name);

            var jsonMessage = JsonConvert.SerializeObject(message);

            var theMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonMessage))
            {

                //Give a unique iDentifier
                CorrelationId = Guid.NewGuid().ToString(),
            };
            //send the Message
            await serviceBusSender.SendMessageAsync(theMessage);
            //clean up Resources
            await serviceBus.DisposeAsync();
        }
    }
}