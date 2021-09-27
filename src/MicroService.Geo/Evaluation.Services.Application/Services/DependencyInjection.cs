using Evaluation.Services.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluation.Services.Application.Services
{
    public  static class DependencyInjection
    {

        public static void AddConfigurationServices(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigurationService config = new ConfigurationService { ConnStringDataBase= configuration["constring-database"], ConnStringServiceBus = configuration["constring-servicebus"] };
           
            services.AddSingleton(config);
        }
    }
}
