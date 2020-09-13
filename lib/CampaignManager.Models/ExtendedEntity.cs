using System;

namespace CampaignManager.Models
{
    public abstract class ExtendedEntity : CampaignEntity
    {       
        public Status Status { get; set; }
        public Coalition Coalition { get; set; }
        public Country Country { get; set; }
    }
}