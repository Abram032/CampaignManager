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

namespace CampaignManager.Api.Location
{
    public static class Update
    {
        [FunctionName("LocationUpdate")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "Locations/{id}")] Models.Location location,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Locations",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] out dynamic document,
            string id,
            ILogger log)
        {
            document = new { 
                id = location.Id,
                campaignId = location.CampaignId,
                name = location.Name,
                description = location.Description,
                country = location.Country,
                coalition = location.Coalition,
                coordinates = location.Coordinates,
                services = location.Services,
                items = location.Items
            };

            log.LogInformation("C# HTTP trigger function processed a request.");
        }
    }
}
