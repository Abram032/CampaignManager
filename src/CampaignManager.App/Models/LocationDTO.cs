using System;
using System.Collections.Generic;
using CampaignManager.Models.Enums;

namespace CampaignManager.App.Models
{
    public class LocationDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CampaignId { get; set; }
        public string Description { get; set; }
        public int FactionId { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public LocationStatus Status { get; set; }
    }
}