using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class Availability
    {
        public int CountryId { get; set; }
        public List<int> ItemIds { get; set; }
    }
}