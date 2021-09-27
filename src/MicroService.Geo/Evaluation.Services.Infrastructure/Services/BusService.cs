using Evaluation.Services.Infrastructure.Configuration;
using Evaluation.Services.Infrastructure.Entities;
using Evaluation.Services.Infrastructure.Services.Interface;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evaluation.Services.Infrastructure.Services
{
        public class BusService : IBusService
        {
            private readonly TopicClient topicClient;
            private readonly ConfigurationService _config;

            public BusService(ConfigurationService config)
            {
                _config = config;
                var TextAppConnectionString = _config.ConnStringServiceBus;
                topicClient = new TopicClient(TextAppConnectionString, "geolocation");

            }

        public async Task SendMessageQueue(Address message, string label, CancellationToken cancellationToken)
        {
            await SendMessage(message, label);
        }


            private async Task SendMessage(dynamic message, string label)
            {
                var jsonString = JsonConvert.SerializeObject(message);
                MemoryStream ms = new MemoryStream(Encoding.Default.GetBytes(jsonString));
                var encodedMessage = new Message(ms.ToArray());
                encodedMessage.Label = label;
                encodedMessage.ContentType = "Application/Json";
                await topicClient.SendAsync(encodedMessage);
            }
        }
    }
