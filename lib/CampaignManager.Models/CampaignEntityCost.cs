using System;

namespace CampaignManager.Models
{
    public class CampaignEntityCost
    {
        public int Id { get; set; }
        public Campaign Campaign { get; set; }
        public Entity Entity { get; set; }
        public decimal Cost { get; set; }
    }
}