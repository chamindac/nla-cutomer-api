using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NLA.CustomerAPI.Repositories;
using NLA.CustomerAPI.Repositories.Data;
using NLA.CustomerAPI.Repositories.Interfaces;
using NLA.CustomerAPI.Services;
using NLA.CustomerAPI.Services.Clients;
using NLA.CustomerAPI.Apis.Extensions;
using NLA.CustomerAPI.RestApi.Mapping;
using NLA.CustomerAPI.RestAPI.Configurations;

namespace NLA.CustomerAPI.RestAPI
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

            var apiSettings = new ApiSettings();
            Configuration.GetSection("ApiSettings").Bind(apiSettings);
            services.AddOptions();
            services.Configure<ApiSettings>(Configuration.GetSection("ApiSettings"));

            services.AddHttpClient<INotificationApiClient, NotificationApiClient>(client =>
            {
                client.BaseAddress = new Uri(apiSettings.NotificationApiUrl);
            });

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddAutoMapperWithDefaultConfiguration(typeof(Startup).Assembly)
                .AddProfileTypes(new HashSet<Type> {
                    typeof(MappingProfile)
                });

            services //.AddEntityFrameworkNpgsql()
                    .AddDbContext<CustomerDbContext>(opt =>
                        opt.UseNpgsql(Configuration.GetConnectionString("CustomerDBConnection"))
                        );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NLA.CustomerAPI.RestAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            // allow swager in none dev envs
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NLA.CustomerAPI.RestAPI v1"));

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
