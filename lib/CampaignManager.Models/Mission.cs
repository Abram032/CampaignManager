using System;
using System.Collections.Generic;
using CampaignManager.Models.Base;

namespace CampaignManager.Models
{
    public class Mission : CampaignEntity
    {
        public string Description { get; set; }
        public Faction Faction { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<Objective> Objectives { get; set; }
        public bool IsActive { get; set; }
    }
}