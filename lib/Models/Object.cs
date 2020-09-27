using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class Object
    {
        public string Id { get; set; }
        public string CampaignId { get; set; }
        public string Name { get; set; }
        public Class Class { get; set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
        public decimal Cost { get; set; }
    }
}