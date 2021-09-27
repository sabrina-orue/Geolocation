using Evaluation.Services.GeoCode.Infrastructure.Configuration;
using Evaluation.Services.GeoCode.Infrastructure.Entities;
using Evaluation.Services.GeoCode.Infrastructure.Services.Interface;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evaluation.Services.GeoCode.Infrastructure.Services
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

        public async Task SendMessageQueue(Coordinates message, string label, CancellationToken cancellationToken)
        {
            await SendMessage(message, "END");
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
