using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CampaignManager.Api.Location
{
    public static class Create
    {
        [FunctionName("LocationCreate")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Location")] Models.Location location,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Locations",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] out dynamic document,
            ILogger log)
        {
            document = new { 
                id = Guid.NewGuid(),
                campaignId = location.CampaignId,
                name = location.Name,
                description = location.Description,
                country = location.Country,
                coalition = location.Coalition,
                coordinates = location.Coordinates,
                services = location.Services,
                fuelQuantity = location.FuelQuantity,
                fuelCost = location.FuelCost,
                isMilitary = location.IsMilitary,
                items = location.Items
            };

            log.LogInformation("C# HTTP trigger function processed a request.");
        }
    }
}
