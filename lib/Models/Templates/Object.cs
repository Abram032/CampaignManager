using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class Object : Entity
    {
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
        public decimal Cost { get; set; }
    }
}