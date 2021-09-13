using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace ApplicationServices.AzureFunctionApp
{
    public static class ReadMessageFromASB
    {
        [FunctionName("ReadMessageFromASB")]
        public static void Run([ServiceBusTrigger("myqueue1", Connection = "AzureWebJobsServiceBus")]string myQueueItem, ILogger log)
        {
            log.LogInformation("************ ReadMessageFromASB function requested ************");

            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");

            log.LogInformation($"************ ReadMessageFromASB processed ************");
        }
    }
}
