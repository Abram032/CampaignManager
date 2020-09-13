using System;

namespace CampaignManager.Models
{
    public class Item : ExtendedEntity
    {
        public Object Object { get; set; }
        public int LocationId { get; set; }
        public Coordinates Coordinates { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}