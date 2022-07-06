using FruitStore.OrderCloud.Api.Interfaces;
using FruitStore.OrderCloud.Api.Services;
using FruitStore.OrderCloud.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Converters;
using OrderCloud.Catalyst;
using OrderCloud.SDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitStore.OrderCloud.Api
{
    public class Startup
    {
        private readonly AppSettings _settings;

        public Startup(IConfiguration configuration, AppSettings settings)
        {
            Configuration = configuration;
            _settings = settings;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers()
                .ConfigureApiBehaviorOptions(o =>
                {
                    o.SuppressModelStateInvalidFilter = true;
                }).AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));
            services.AddMvc(o =>
            {
                o.Filters.Add(new ValidateModelAttribute());
                o.EnableEndpointRouting = false;
            });
            services.AddCors(o => o.AddPolicy("integrationcors",
                builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

            // Overridden the Authentication part due to one issue. This has to be removed
            services
                .AddHttpContextAccessor()
                .AddSingleton<RequestAuthenticationService>()
                .AddSingleton<ISimpleCache, LazyCacheService>() // Can override by registering own implmentation
                .AddAuthentication()
                .AddScheme<OrderCloudUserAuthOptions, OrderCloudUserAuthHandler>("OrderCloudUser", null, options => options.AddValidClientIDs(_settings.OrderCloudSettings.MiddlewareClientID));
            ////////////
            services
                //.AddOrderCloudUserAuth(opts => opts.AddValidClientIDs(_settings.OrderCloudSettings.MiddlewareClientID))
                .AddSingleton<ISimpleCache, LazyCacheService>() // Replace LazyCacheService with RedisService if you have multiple server instances.
                .AddSingleton<IProductServices, OCProductServices>()
                .AddSingleton<IOrderCloudClient>(new OrderCloudClient(new OrderCloudClientConfig()
                {
                    ApiUrl = _settings.OrderCloudSettings.ApiUrl,
                    ClientId = _settings.OrderCloudSettings.MiddlewareClientID,
                    ClientSecret = _settings.OrderCloudSettings.MiddlewareClientSecret,
                    Roles = new[] { ApiRole.FullAccess },
                }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
