using System;
using System.Collections.Generic;
using CampaignManager.Models.Enums;

namespace CampaignManager.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Campaign Campaign { get; set; }
        public string Description { get; set; }
        public Faction Faction { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public List<Service> Services { get; set; }
        public LocationStatus Status { get; set; }
        public List<CampaignEntity> Entities { get; set; }
    }
}