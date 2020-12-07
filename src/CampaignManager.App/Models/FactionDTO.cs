using System;
using System.Collections.Generic;

namespace CampaignManager.App.Models
{
    public class FactionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CampaignId { get; set; }
        public int CoalitionId { get; set; }
        public int CountryId { get; set; }
        public decimal Budget { get; set; }
    }
}