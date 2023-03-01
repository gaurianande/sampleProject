using ECommerce.Application.Extensions;
using Microsoft.AspNetCore;
using Azure.Identity;
using Microsoft.Extensions.Configuration;

namespace SampleECommerceWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) =>
                { 
                        config.ConfigureKeyVault();
                    var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
                    config.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());
                })
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}


