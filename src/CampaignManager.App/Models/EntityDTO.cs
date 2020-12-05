using CampaignManager.Models.Enums;

namespace CampaignManager.Models
{
    public class EntityDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public decimal DefaultCost { get; set; }
    }
}