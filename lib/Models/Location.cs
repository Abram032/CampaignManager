using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class Location
    {
        public string Id { get; set; }
        public string CampaignId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Country Country { get; set; }
        public Coalition Coalition { get; set; }
        public Coordinates Coordinates { get; set; }
        public List<Service> Services { get; set; }
        public Status Status { get; set; }
        public List<Item> Items { get; set; }
    }
}