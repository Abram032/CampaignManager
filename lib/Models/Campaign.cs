using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class Campaign
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Participant> Participants { get; set; }
        public List<Mission> Missions { get; set; }
        public bool IsActive { get; set; }
    }
}