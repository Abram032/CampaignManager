using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class Mission
    {      
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Country Country { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Objective> Objectives { get; set; }
        public bool IsActive { get; set; }
    }
}