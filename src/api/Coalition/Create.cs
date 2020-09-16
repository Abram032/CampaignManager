using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CampaignManager.Api.Coalition
{
    public static class Create
    {
        [FunctionName("CoalitionCreate")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Coalition")] Models.Coalition coalition,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Coalitions",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] out dynamic document,
            ILogger log)
        {
            document = new { 
                id = Guid.NewGuid(),
                campaignId = coalition.CampaignId,
                name = coalition.Name
            };

            log.LogInformation("C# HTTP trigger function processed a request.");
        }
    }
}
