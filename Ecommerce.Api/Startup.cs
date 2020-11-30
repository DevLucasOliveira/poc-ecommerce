using Ecommerce.Domain.StoreContext.Handlers;
using Ecommerce.Domain.StoreContext.Repositories;
using Ecommerce.Domain.StoreContext.Services;
using Ecommerce.Infra.Context;
using Ecommerce.Infra.Repositories;
using Ecommerce.Infra.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Ecommerce.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddScoped<CustomerHandler, CustomerHandler>();
            services.AddScoped<DataContext, DataContext>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();
        }
    }
}
