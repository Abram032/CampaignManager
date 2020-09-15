using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class Unit
    {
        public int Id { get; set; }
        public int CampaignId { get; set; }
        public int MissionId { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
        public Status Status { get; set; }
        public Coalition Coalition { get; set; }
        public Country Country { get; set; }
    }
}