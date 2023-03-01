using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Extensions
{
    public static class ConfigureKeyVaultExtensions
    {
        public static void ConfigureKeyVault(this IConfigurationBuilder config)
        {
            var settings = config.Build();

            var keyVaultEndpoint = settings["AzureKeyVault:Endpoint"];
            var keyVaultClientId = settings["AzureKeyVault:ClientId"];
            var keyVaultClientSecret = settings["AzureKeyVault:ClientSecret"];

            if (keyVaultEndpoint is null)
                throw new InvalidOperationException("Store the Key Vault endpoint in a KEYVAULT_ENDPOINT environment variable.");

            config.AddAzureKeyVault(keyVaultEndpoint, keyVaultClientId, keyVaultClientSecret, new DefaultKeyVaultSecretManager());
        }
    }
}
