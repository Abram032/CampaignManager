using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace CampaignManager.Api.Object
{
    public static class Update
    {
        [FunctionName("ObjectUpdate")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "Objects/{id}")] Models.Object @object,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Objects",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] out dynamic document,
            string id,
            ILogger log)
        {
            document = new { 
                id = @object.Id,
                campaignId = @object.CampaignId,
                name = @object.Name,
                category = @object.Category,
                subcategory = @object.Subcategory,
                cost = @object.Cost
            };

            log.LogInformation("C# HTTP trigger function processed a request.");
        }
    }
}
