using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string Status { get; set; }
        public string Coalition { get; set; }
        public string Country { get; set; }
    }
}