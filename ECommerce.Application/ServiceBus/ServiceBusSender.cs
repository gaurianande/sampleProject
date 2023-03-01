using Azure.Messaging.ServiceBus;
using Ecommerce.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.Application.ServiceBus
{
    public class ServiceBusSender
    {
        private readonly ServiceBusClient _client;
        private readonly Azure.Messaging.ServiceBus.ServiceBusSender _clientSender;
        private const string QUEUE_NAME = "product-add-queue";

        public ServiceBusSender(IConfiguration configuration)
        {
            var connectionString = configuration["sevicebusconnection"];
            _client = new ServiceBusClient(connectionString);
            _clientSender = _client.CreateSender(QUEUE_NAME);
        }

        public async Task SendMessage(Product product)
        {
            string messagePayload = JsonSerializer.Serialize(product);
            ServiceBusMessage message = new ServiceBusMessage(messagePayload);
            await _clientSender.SendMessageAsync(message).ConfigureAwait(false);
        }
    }
}
