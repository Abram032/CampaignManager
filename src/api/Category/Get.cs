using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CampaignManager.Models.Templates;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents;

namespace CampaignManager.Api.Object
{
    public static class Get
    {
        [FunctionName("CategoryGet")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous, "get", 
                Route = "Category"
            )] HttpRequest req,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Categories",
                Id = "{Query.id}",
                PartitionKey = "{Query.partitionKey}",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] Category category,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            return new OkObjectResult(category);
        }
    }
}