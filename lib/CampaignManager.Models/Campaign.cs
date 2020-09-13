using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class Campaign : Entity
    {
        public string Currency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Participant> Participants { get; set; }
        public bool IsActive { get; set; }
    }
}