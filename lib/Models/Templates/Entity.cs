using System;

namespace CampaignManager.Models
{
    public class Entity
    {        
        public Guid Id { get; set; }
        public Guid CampaignId { get; set; }
        public string Name { get; set; }
    }
}