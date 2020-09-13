using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class Location : ExtendedEntity
    {
        public Coordinates Coordinates { get; set; }
        public List<Service> Services { get; set; }  
        public double FuelQuantity { get; set; }
        public bool IsMilitary { get; set; }
        public List<int> ItemIds { get; set; }
    }
}