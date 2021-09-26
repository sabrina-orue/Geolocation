using Evaluation.Services.Application.Services;
using Evaluation.Services.Infrastructure.Context;
using Evaluation.Services.Infrastructure.Repository;
using Evaluation.Services.Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using MediatR;
using Evaluation.Services.Application.Mapper;

namespace Evaluation.Services
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<GeolocationContext>(options =>
               options.UseSqlServer(Configuration["constring-database"]));

            services.AddMvc();

            services.AddMappers();

            services.AddRepositories();

            services.AddServices();
            services.AddControllers();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddCors();
            services.AddConfigurationServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", $"{Configuration.GetValue<string>("ApiName")} {Configuration.GetValue<string>("ApiVersion")}"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
