using System;
using System.Collections.Generic;
using CampaignManager.Models.Templates;

namespace CampaignManager.Models
{
    public class Mission
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Objective> Objectives { get; set; }
        public bool IsActive { get; set; }
    }
}