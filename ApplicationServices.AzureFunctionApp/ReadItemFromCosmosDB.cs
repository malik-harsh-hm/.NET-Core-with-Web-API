using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ApplicationServices.AzureFunctionApp.Models;

namespace ApplicationServices.AzureFunctionApp
{
    public static class ReadItemFromCosmosDB
    {
        // GET: http://localhost:7071/api/Bookmarks/id-here
        [FunctionName("ReadItemFromCosmosDB")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "Bookmarks/{id}")] HttpRequest req,
            [CosmosDB(
                databaseName: "my-database-1",
                collectionName: "Bookmarks",
                ConnectionStringSetting = "CosmosDBConnection",
                PartitionKey = "{id}",
                Id = "{id}")] Bookmark item,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            if (item == null)
            {
                return new NotFoundObjectResult(item);
            }
            else
            {
                return new OkObjectResult(item);
            }
        }
    }
}
