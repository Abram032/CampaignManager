using System;
using System.Collections.Generic;
using CampaignManager.Models.Base;

namespace CampaignManager.Models
{
    public class Campaign : Entity
    {
        public string Abbreviation { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<Faction> Factions { get; set; }
        public bool IsActive { get; set; }
    }
}