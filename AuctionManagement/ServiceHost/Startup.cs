using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuctionManagement.Config;
using AuctionManagement.Gateways.RestApi;
using Autofac;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using ServiceHost.Configuration;

namespace ServiceHost
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public ServiceHostConfig ServiceHostConfig { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ServiceHostConfig = configuration.GetSection("ServiceHostConfig").Get<ServiceHostConfig>();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.ApiName = "auction-api";
                    options.RequireHttpsMetadata = false;
                });

            //services.AddMvc(a=>a.Filters.Add(new AuthorizeFilter()))
            services.AddMvc()
                .AddApplicationPart(typeof(AuctionsController).Assembly)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var auctionConfig = Configuration.GetSection("AuctionConfig").Get<AuctionConfig>();
            builder.RegisterModule(new AuctionModule(auctionConfig));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseCors(builder => builder
                .WithOrigins(ServiceHostConfig.AllowedOrigins)
                .AllowAnyHeader()
                .AllowAnyMethod());
            app.UseMvcWithDefaultRoute();
        }
    }
}
