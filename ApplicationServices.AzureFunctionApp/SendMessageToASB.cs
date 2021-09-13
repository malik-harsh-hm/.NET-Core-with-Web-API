using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.ServiceBus;
using System.Text;

namespace ApplicationServices.AzureFunctionApp
{
    public static class SendMessageToASB
    {
        [FunctionName("SendMessageToASB")]
        [return: ServiceBus("myqueue1", EntityType.Queue, Connection = "AzureWebJobsServiceBus")]

        public static async Task<string> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("************ SendMessageToASB function requested ************");
            string body = string.Empty;
            using (var reader = new StreamReader(req.Body, Encoding.UTF8))
            {
                body = await reader.ReadToEndAsync();
                log.LogInformation($"Message body : {body}");
            }
            log.LogInformation($"************ SendMessageToASB processed ************");
            return body;
        }
    }
}
