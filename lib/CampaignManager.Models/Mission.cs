using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class Mission : CampaignEntity
    {
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<int> ItemIds { get; set; }
        public List<int> LocationIds { get; set; }
        public List<Objective> Objectives { get; set; }
    }
}