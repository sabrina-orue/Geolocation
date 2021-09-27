using Evaluation.Services.Infrastructure.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluation.Services.Infrastructure.Repository
{
   public  static class DependencyInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();

        }
    }
}
