using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class Participant
    {
        public string Name { get; set; }
        public Country Country { get; set; }
        public Coalition Coalition { get; set; }
        public decimal Budget { get; set; }
    }
}