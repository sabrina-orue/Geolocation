using Evaluation.Services.Infrastructure.Services;
using Evaluation.Services.Infrastructure.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluation.Services.Infrastructure.Services
{
   public  static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBusService, BusService>();
        }
    }
}
