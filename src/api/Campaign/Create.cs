using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CampaignManager.Api.Campaign
{
    public static class Create
    {
        [FunctionName("CampaignCreate")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Campaign")] Models.Campaign campaign,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Campaigns",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] out dynamic document,
            ILogger log)
        {
            var guid = Guid.NewGuid();
            document = new { 
                id = guid,
                partitionKey = guid,
                name = campaign.Name,
                description = campaign.Description,
                startDate = campaign.StartDate,
                endDate = campaign.EndDate,
                isActive = campaign.IsActive,
                currency = campaign.Currency,
                missions = campaign.Missions,
                participants = campaign.Participants
            };

            log.LogInformation("C# HTTP trigger function processed a request.");
        }
    }
}
