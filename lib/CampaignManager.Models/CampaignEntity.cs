using System;
using CampaignManager.Models.Enums;

namespace CampaignManager.Models
{
    public class CampaignEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Campaign Campaign { get; set; }
        public Location Location { get; set; }
        public Entity Entity { get; set; }
        public EntityStatus Status { get; set; }
        public Faction Faction { get; set; }
        public DateTime? AvailableAt { get; set; }
        public int Count { get; set; }
    }
}