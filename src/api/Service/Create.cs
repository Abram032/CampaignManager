using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CampaignManager.Api.Service
{
    public static class Create
    {
        [FunctionName("ServiceCreate")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Service")] Models.Service service,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Services",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] out dynamic document,
            ILogger log)
        {
            document = new { 
                id = Guid.NewGuid(),
                campaignId = service.CampaignId,
                name = service.Name
            };

            log.LogInformation("C# HTTP trigger function processed a request.");
        }
    }
}
