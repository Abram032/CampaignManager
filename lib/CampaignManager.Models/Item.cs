using System;
using CampaignManager.Models.Base;
using CampaignManager.Models.Enums;

namespace CampaignManager.Models
{
    public class Item : CampaignEntity
    {
        public Location Location { get; set; }
        public Object Object { get; set; }
        public Status Status { get; set; }
        public Faction Faction { get; set; }
        public DateTime? AvailableAt { get; set; }
        public int Count { get; set; }
    }
}