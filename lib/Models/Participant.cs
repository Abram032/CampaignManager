using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class Participant
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Coalition { get; set; }
        public decimal Budget { get; set; }
    }
}