using System;
using System.Collections.Generic;
using CampaignManager.Models.Base;

namespace CampaignManager.Models
{
    public class Objective : Entity
    {
        public string Description { get; set; }
        public bool Completed { get; set; }
    }
}