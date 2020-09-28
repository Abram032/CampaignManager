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
using System.Collections.Generic;
using Microsoft.Azure.Documents.Linq;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.Azure.Documents;
using Newtonsoft.Json.Serialization;

namespace CampaignManager.Api.Campaign  
{
    public static class Create
    {
        [FunctionName("CampaignCreate")]
        public static async Task Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Campaigns")] Models.Campaign campaign,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Campaigns",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING")] DocumentClient campaignClient,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Objects",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING")] DocumentClient objectClient,
            [CosmosDB(
                databaseName: "CampaignManager",
                collectionName: "Locations",
                ConnectionStringSetting = "AZURE_COSMOS_DB_CONNECTION_STRING")] DocumentClient locationClient,    
            ILogger log)
        {
            var guid = Guid.NewGuid();
            var _campaign = new { 
                id = guid,
                campaignId = guid,
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

            var requestOptions = new RequestOptions
            {
                JsonSerializerSettings = new JsonSerializerSettings 
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                }
            };

            await campaignClient.CreateDocumentAsync($"dbs/CampaignManager/colls/Campaigns/", _campaign, requestOptions);

            var objects = await GetItemsAsync<Models.Object>(objectClient, "CampaignManager", "Objects", Guid.Empty.ToString(), (x => true));

            foreach(var @object in objects)
            {
                @object.CampaignId = guid.ToString();
                await objectClient.CreateDocumentAsync($"dbs/CampaignManager/colls/Objects/", @object, requestOptions);
            }

            var locations = await GetItemsAsync<Models.Location>(locationClient, "CampaignManager", "Locations", Guid.Empty.ToString(), (x => true));

            foreach(var location in locations)
            {
                location.CampaignId = guid.ToString();
                await objectClient.CreateDocumentAsync($"dbs/CampaignManager/colls/Locations/", location, requestOptions);
            }

            log.LogInformation("C# HTTP trigger function processed a request.");
        }

        public static async Task<IEnumerable<T>> GetItemsAsync<T>(DocumentClient client, string databaseId, 
            string collectionId, string partitionKey, Expression<Func<T, bool>> predicate) where T : class
        {
            IDocumentQuery<T> query = client.CreateDocumentQuery<T>(
                UriFactory.CreateDocumentCollectionUri(databaseId, collectionId),
                new FeedOptions { MaxItemCount = -1, PartitionKey = new PartitionKey(partitionKey) })
                .Where(predicate)
                .AsDocumentQuery();

            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;
        }
    }
}
