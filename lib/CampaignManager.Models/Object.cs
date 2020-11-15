
using CampaignManager.Models.Base;
using CampaignManager.Models.Enums;

namespace CampaignManager.Models
{
    public class Object : Entity
    {
        public Type Type { get; set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
        public decimal DefaultCost { get; set; }
    }
}