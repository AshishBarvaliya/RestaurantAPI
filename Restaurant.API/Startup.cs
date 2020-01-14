using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant.Helpers;
using Newtonsoft.Json.Serialization;
using Restaurant.Services;
using System.Configuration;

namespace Restaurant.API
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
            services.AddControllers(setupAction =>
            {
                setupAction.ReturnHttpNotAcceptable = true;
            })
                .AddXmlDataContractSerializerFormatters();

            services.AddControllers()
                    .AddNewtonsoftJson( options =>
                                  {
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                         });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IRepository, Repository>();

            services.AddDbContext<DbContext.DbContext>(options =>
            {
               options.UseSqlServer(Configuration.GetConnectionString("RestaurantDBConnection"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}