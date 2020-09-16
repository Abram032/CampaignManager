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

namespace CampaignManager.Api.Service
{
    public static class Update
    {
        [FunctionName("ServiceUpdate")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "Service")] Models.Service service,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Services",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] out dynamic document,
            ILogger log)
        {
            document = new { 
                id = service.Id,
                campaignId = service.CampaignId,
                name = service.Name
            };

            log.LogInformation("C# HTTP trigger function processed a request.");
        }
    }
}
