using AutoMapper;
using Microsoft.Extensions.DependencyInjection;


namespace Evaluation.Services.GeoCode.Application.Mapper
{
    public static class DependencyInjection
    {
        public static void AddMappers(this IServiceCollection services)
        {
            var config = new MapperConfiguration(m =>
            {
                m.AddProfile(typeof(AddressProfile));
            });

            services.AddSingleton(config.CreateMapper());
        }

    }

}
