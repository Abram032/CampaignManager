using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CampaignManager.Api.Object
{
    public static class Create
    {
        [FunctionName("ObjectCreate")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Objects")] Models.Object @object,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Objects",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] out dynamic document,
            ILogger log)
        {
            document = new { 
                id = Guid.NewGuid(),
                campaignId = @object.CampaignId,
                name = @object.Name,
                @class = @object.Class,
                category = @object.Category,
                subcategory = @object.Subcategory,
                cost = @object.Cost
            };

            log.LogInformation("C# HTTP trigger function processed a request.");
        }
    }
}
