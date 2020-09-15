using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class UnitCount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CampaignId { get; set; }
        public Unit Unit { get; set; }
        public int Count { get; set; }
    }
}