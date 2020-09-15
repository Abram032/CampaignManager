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
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace CampaignManager.Api.Object
{
    public static class Update
    {
        [FunctionName("CategoryUpdate")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "Category")] Category category,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Categories",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] out dynamic document,
            ILogger log)
        {
            document = new { 
                id = category.Id,
                campaignId = category.CampaignId,
                name = category.Name
            };

            log.LogInformation("C# HTTP trigger function processed a request.");
        }
    }
}
