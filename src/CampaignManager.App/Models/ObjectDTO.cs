using CampaignManager.Models.Base;
using CampaignManager.Models.Enums;

namespace CampaignManager.Models
{
    public class ObjectDTO : Entity
    {
        public Type Type { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public decimal DefaultCost { get; set; }
    }
}