using System;
using System.Collections.Generic;
using CampaignManager.Models.Base;

namespace CampaignManager.Models
{
    public class Faction : CampaignEntity
    {
        public Coalition Coalition { get; set; }
        public Country Country { get; set; }
        public List<Location> Locations { get; set; }
        public List<Mission> Missions { get; set; }
        public decimal Budget { get; set; }
    }
}