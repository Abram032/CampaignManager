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

namespace CampaignManager.Api.Country
{
    public static class Update
    {
        [FunctionName("CountryUpdate")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "Country")] Models.Country country,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Countries",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING"
            )] out dynamic document,
            ILogger log)
        {
            document = new { 
                id = country.Id,
                campaignId = country.CampaignId,
                name = country.Name
            };

            log.LogInformation("C# HTTP trigger function processed a request.");
        }
    }
}
