using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class Location
    {
        public Guid Id { get; set; }
        public Guid CampaignId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string Coalition { get; set; }
        public Coordinates Coordinates { get; set; }
        public List<string> Services { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelCost { get; set; }
        public bool IsMilitary { get; set; }
        public string Status { get; set; }
        public List<Item> Items { get; set; }
    }
}