using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using System;

namespace Evaluation.Services.GeoCode.Application.KeyVault
{
    public static class ConfigurationBuilderExtensions
    {
        public static void ConfigureKeyVault(this IConfigurationBuilder config, string keyVaultEndpoint)
        {
           
            var secretClient = new SecretClient(new Uri(keyVaultEndpoint), new DefaultAzureCredential());
            config.AddAzureKeyVault(secretClient, new KeyVaultSecretManager());

        }
    }
}
