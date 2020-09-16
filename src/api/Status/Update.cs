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

namespace CampaignManager.Api.Status
{
    public static class Update
    {
        [FunctionName("StatusUpdate")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "Status")] Models.Status status,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Statuses",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] out dynamic document,
            ILogger log)
        {
            document = new { 
                id = status.Id,
                campaignId = status.CampaignId,
                name = status.Name
            };

            log.LogInformation("C# HTTP trigger function processed a request.");
        }
    }
}
