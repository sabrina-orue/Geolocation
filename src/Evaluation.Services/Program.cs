using Evaluation.Services.Application.KeyVault;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evaluation.Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args, webBuilder => webBuilder.UseStartup<Startup>()).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args, Action<IWebHostBuilder> configure)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, config) => {
                    String keyVaultEndpoint = null;

                    if (context.HostingEnvironment.IsProduction())
                        keyVaultEndpoint = Environment.GetEnvironmentVariable("KEYVAULT_ENDPOINT");
                    else
                    {
                        var buildConfig = config.Build();
                        keyVaultEndpoint = buildConfig["KeyVault:Endpoint"];
                    }

                    if (keyVaultEndpoint is null)
                        throw new InvalidOperationException("Store the Key Vault endpoint in a KEYVAULT_ENDPOINT environment variable.");

                    config.ConfigureKeyVault(keyVaultEndpoint);
                })
                .ConfigureWebHostDefaults(configure =>
                {
                    configure.UseStartup<Startup>();
                });
        }

       
    }

    
}
