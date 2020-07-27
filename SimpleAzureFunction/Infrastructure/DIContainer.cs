using AzureQueueLibrary.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleAzureFunction.Email;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SimpleAzureFunction.Infrastructure
{
    public sealed class DIContainer
    {
        private static readonly IServiceProvider _instance = Build();
        public static IServiceProvider Instance => _instance;
         
        public DIContainer()
        {

        }

        private static IServiceProvider Build()
        {
            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            services.AddSingleton
                (
                    new EmailConfig
                    (
                        configuration["EmailHost"],
                        Convert.ToInt32(configuration["EmailPort"]),
                        configuration["EmailSender"],
                        configuration["EmailPassword"]
                    )
                );

            services.AddSingleton<ISendEmailCommandHandler, SendEmailCommandHandler>();
            services.AddAzureQueueLibrary(configuration["AzureWebJobsStorage"]);

            return services.BuildServiceProvider();
        }
    }
}
