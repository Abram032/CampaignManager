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
    public static class Delete
    {
        [FunctionName("ObjectDelete")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous, "delete", 
                Route = "Objects/{id}"
            )] HttpRequest req,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Objects",
                Id = "{id}",
                PartitionKey = "{Query.campaignId}",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] Document document,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Objects",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] DocumentClient client,
            string id,
            ILogger log)
        {
            string campaignId = req.Query["campaignId"];
            await client.DeleteDocumentAsync(document.SelfLink, new RequestOptions() { PartitionKey = new PartitionKey(campaignId)});

            log.LogInformation("C# HTTP trigger function processed a request.");

            return new OkResult();
        }
    }
}