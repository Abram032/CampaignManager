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

namespace CampaignManager.Api.Campaign
{
    public static class Update
    {
        [FunctionName("CampaignUpdate")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "Campaigns/{id}")] Models.Campaign campaign,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Campaigns",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] out dynamic document,
            string id,
            ILogger log)
        {
            document = new { 
                id = campaign.Id,
                campaignId = campaign.CampaignId,
                name = campaign.Name,
                shortcut = campaign.Shortcut,
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
