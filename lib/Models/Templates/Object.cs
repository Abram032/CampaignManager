using System;
using System.Collections.Generic;

namespace CampaignManager.Models.Templates
{
    public class Object : Entity
    {
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public decimal Cost { get; set; }
    }
}