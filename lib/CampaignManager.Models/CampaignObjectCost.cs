using System;
using CampaignManager.Models.Base;
using CampaignManager.Models.Enums;

namespace CampaignManager.Models
{
    public class CampaignObjectCost : CampaignEntity
    {
        public Object Object { get; set; }
        public decimal Cost { get; set; }
    }
}