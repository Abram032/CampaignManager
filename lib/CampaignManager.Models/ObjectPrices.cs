using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class ObjectPrices : CampaignEntity
    {
        public int ObjectId { get; set; }
        public decimal Price { get; set; }
    }
}