using System;

namespace CampaignManager.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}