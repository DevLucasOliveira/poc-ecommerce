using Ecommerce.Domain.StoreContext.Handlers;
using Ecommerce.Domain.StoreContext.Repositories;
using Ecommerce.Domain.StoreContext.Services;
using Ecommerce.Infra.Context;
using Ecommerce.Infra.Repositories;
using Ecommerce.Infra.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Ecommerce.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddResponseCompression();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddScoped<CustomerHandler, CustomerHandler>();
            services.AddScoped<DataContext, DataContext>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Devlucasoliveira",
                    Version = "v1"
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Devlucasoliveira");
            });

            app.UseResponseCompression();
        }
    }
}
