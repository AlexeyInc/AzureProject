using System;
using System.Threading.Tasks;
using AzureQueueLibrary.Infrastructure;
using AzureQueueLibrary.Messages;
using AzureQueueLibrary.QueueConnection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using SimpleAzureFunction.Infrastructure;
using Microsoft.Extensions.DependencyInjection;


namespace SimpleAzureFunction.Email
{
    public static class EmailQueueTrigger
    {
        [FunctionName("EmailQueueTrigger")]
        public static async Task Run(
            [QueueTrigger(RouteNames.EmailBox, Connection = "AzureWebJobsStorage")]string message, 
            ILogger log)
        {
            try
            {
                var queueCommunicator = DIContainer.Instance.GetService<IQueueCommunicator>();
                var command = queueCommunicator.Read<SendEmailCommand>(message);

                var handler = DIContainer.Instance.GetService<ISendEmailCommandHandler>();
                await handler.Handle(command);
            }
            catch (Exception ex)
            {
                log.LogError(ex, $"Smth went wrong with emailQueueTrigger {message}");
                throw;
            }
        }
    }
}
