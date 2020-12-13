using System;
using CampaignManager.Models.Enums;

namespace CampaignManager.App.Models
{
    public class CampaignEntityDTO
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public int LocationId { get; set; }
        public int EntityId { get; set; }
        public EntityStatus Status { get; set; }
        public int Count { get; set; }
    }
}