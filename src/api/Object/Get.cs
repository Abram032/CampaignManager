using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents;

namespace CampaignManager.Api.Object
{
    public static class Get
    {
        [FunctionName("ObjectGet")]
        public static IActionResult Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous, "get", 
                Route = "Object"
            )] HttpRequest req,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Objects",
                Id = "{Query.id}",
                PartitionKey = "{Query.campaignId}",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] Models.Object @object,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            return new OkObjectResult(@object);
        }
    }
}