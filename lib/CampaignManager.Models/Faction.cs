using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class Faction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Campaign Campaign { get; set; }
        public Coalition Coalition { get; set; }
        public Country Country { get; set; }
        public List<Location> Locations { get; set; }
        public List<Mission> Missions { get; set; }
        public decimal Budget { get; set; }
    }
}