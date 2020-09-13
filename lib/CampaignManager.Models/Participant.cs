using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class Participant : CampaignEntity
    {
        public int CountryId { get; set; }
        public Coalition Coalition { get; set; }
        public decimal Budget { get; set; }
        public List<int> LocationIds { get; set; }
    }
}