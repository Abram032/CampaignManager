using System;
using System.Collections.Generic;
using CampaignManager.Models.Base;

namespace CampaignManager.Models
{
    public class Location : CampaignEntity
    {
        public string Description { get; set; }
        public Faction Faction { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public List<Service> Services { get; set; }
        public Status Status { get; set; }
        public List<Item> Items { get; set; }
    }
}