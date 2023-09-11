using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Email_Service.Messaging
{
    public interface IAzureMessageBusEndUser
    {
        Task Start();
        Task Stop();
    }
}