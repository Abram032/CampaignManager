using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class Campaign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Currency { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Participant> Participants { get; set; }
        public List<int> MissionIds { get; set; }
        public bool IsActive { get; set; }
    }
}