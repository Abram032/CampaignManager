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
    public static class Delete
    {
        [FunctionName("CategoryDelete")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous, "delete", 
                Route = "Category"
            )] HttpRequest req,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Categories",
                Id = "{Query.id}",
                PartitionKey = "{Query.partitionKey}",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] Document document,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Categories",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] DocumentClient client,
            ILogger log)
        {
            string partitionKey = req.Query["partitionKey"];
            await client.DeleteDocumentAsync(document.SelfLink, new RequestOptions() { PartitionKey = new PartitionKey(partitionKey)});

            log.LogInformation("C# HTTP trigger function processed a request.");

            return new OkResult();
        }
    }
}