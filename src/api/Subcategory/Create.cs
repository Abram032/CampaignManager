using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CampaignManager.Api.Subcategory
{
    public static class Create
    {
        [FunctionName("SubcategoryCreate")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Subcategory")] Models.Subcategory subcategory,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Subcategories",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] out dynamic document,
            ILogger log)
        {
            document = new { 
                id = Guid.NewGuid(),
                campaignId = subcategory.CampaignId,
                name = subcategory.Name
            };

            log.LogInformation("C# HTTP trigger function processed a request.");
        }
    }
}
