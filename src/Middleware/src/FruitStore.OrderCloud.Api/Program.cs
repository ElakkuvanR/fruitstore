using FruitStore.OrderCloud.Common;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace FruitStore.OrderCloud.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Links to an Azure App Configuration resource that holds the app settings.
            // For local development, set this in your visual studio Env Variables.
            var appConfigConnectionString = Environment.GetEnvironmentVariable("APP_CONFIG_CONNECTION");

            WebHost.CreateDefaultBuilder(args)
                .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .ConfigureAppConfiguration((context, config) =>
                {
                    if (appConfigConnectionString != null)
                    {
                        config.AddAzureAppConfiguration(appConfigConnectionString);
                    }
                    config.AddJsonFile("appSettings.json", optional: false);
                })
                .UseStartup<Startup>()
                .ConfigureServices((ctx, services) =>
                {
                    services.Configure<AppSettings>(ctx.Configuration);
                    services.AddTransient(sp => sp.GetService<IOptionsSnapshot<AppSettings>>().Value);
                })
                .Build()
                .Run();
        }
    }
}
