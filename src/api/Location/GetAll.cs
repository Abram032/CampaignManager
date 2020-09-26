using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents;
using System.Collections.Generic;

namespace CampaignManager.Api.Location
{
    public static class GetAll
    {
        [FunctionName("LocationGetAll")]
        public static IActionResult Run(
            [HttpTrigger(
                AuthorizationLevel.Anonymous, "get", 
                Route = "Locations"
            )] HttpRequest req,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Locations",
                PartitionKey = "{Query.campaignId}",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] IEnumerable<Models.Location> location,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            return new OkObjectResult(location);
        }
    }
}