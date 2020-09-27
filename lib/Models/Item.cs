using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CampaignManager.Models
{
    public class Item
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Class Class { get; set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
        public Status Status { get; set; }
        public Coalition Coalition { get; set; }
        public Country Country { get; set; }
        public bool UsesTemplate { get; set; }
        public DateTime AvailableAt { get; set; }
        private int count;
        public int Count
        {
            get { return count; }
            set
            {
                if (value < 0)
                    count = 0;
                else
                    count = value;
            }
        }     

        public Item()
        {
            Id = Guid.NewGuid().ToString();
            UsesTemplate = true;
        }
    }
}