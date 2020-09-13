using System;
using System.Collections.Generic;

namespace CampaignManager.Models.Templates
{
    public class Object
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
        public int Lifespan { get; set; }
        public double Size { get; set; }
    }
}