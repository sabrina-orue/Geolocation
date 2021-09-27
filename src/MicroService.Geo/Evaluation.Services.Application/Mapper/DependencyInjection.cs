using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evaluation.Services.Application.Mapper
{
    public static class DependencyInjection
    {
        public static void AddMappers(this IServiceCollection services)
        {
            var config = new MapperConfiguration(m =>
            {
                m.AddProfile(typeof(AddressProfile));
                m.AddProfile(typeof(LocationProfile));

            });

            services.AddSingleton(config.CreateMapper());
        }

    }

}
