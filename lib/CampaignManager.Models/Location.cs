using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class Location
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public int MissionId { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public Coalition Coalition { get; set; }
        public Coordinates Coordinates { get; set; }
        public List<Service> Services { get; set; }  
        public double FuelQuantity { get; set; }
        public bool IsMilitary { get; set; }
        public List<UnitCount> Units { get; set; }
    }
}