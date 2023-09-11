using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Email_Service.Messaging;

namespace Email_Service.Extensions
{
    public static class AzureServiceStarter
    {
        public static IAzureMessageBusEndUser ServiceBusConsumerInstance { get; set; }
        public static IApplicationBuilder useAzure(this IApplicationBuilder app)
        {
            ServiceBusConsumerInstance = app.ApplicationServices.GetService<IAzureMessageBusEndUser>();

            var HostLifetime = app.ApplicationServices.GetService<IHostApplicationLifetime>();

            HostLifetime.ApplicationStarted.Register(OnStart);
            HostLifetime.ApplicationStopping.Register(OnStop);

            return app;
        }

        private static void OnStop()
        {
            ServiceBusConsumerInstance.Stop();
        }

        private static void OnStart()
        {
            ServiceBusConsumerInstance.Start();
        }
    }
}