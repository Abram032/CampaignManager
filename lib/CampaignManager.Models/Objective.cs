using System;
using System.Collections.Generic;

namespace CampaignManager.Models
{
    public class Objective
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}