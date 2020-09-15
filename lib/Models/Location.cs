using System;
using System.Collections.Generic;
using CampaignManager.Models.Templates;

namespace CampaignManager.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public Guid CampaignId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Coalition { get; set; }
        public Coordinates Coordinates { get; set; }
        public List<Service> Services { get; set; }  
        public double FuelQuantity { get; set; }
        public bool IsMilitary { get; set; }
        public List<ItemCount> Items { get; set; }
    }
}