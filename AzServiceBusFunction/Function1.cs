using System;
using Ecommerce.Domain.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzServiceBusFunction
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [FunctionName("ReadMessageFromQueue")]
        public void Run([ServiceBusTrigger("product-add-queue", Connection = "Endpoint=sb://productsns.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=7VJfjTA5LnowycP9++yIJmkPttBl4XjaO+ASbCwOEbw=")] string myQueueItem, ILogger log)
        {
            _logger.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            var input = JsonConvert.DeserializeObject<Product>(myQueueItem);
            try
            {
                using (SqlConnection connection = new SqlConnection(Environment.GetEnvironmentVariable("sqlConnectionString")))
                {
                    connection.Open();
                    if (!String.IsNullOrEmpty(input.ToString()))
                    {
                        var query = $"INSERT INTO [dbo].[product] (Id,Name,Description,Price,CreatedAt,UpdatedAt) VALUES('{input.Id}', '{input.Name}' , '{input.Description}', '{input.Price}', '{input.CreatedAt}', '{input.UpdatedAt}')";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
            }
        }
    }
}
