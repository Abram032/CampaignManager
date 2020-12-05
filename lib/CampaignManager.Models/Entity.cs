using CampaignManager.Models.Enums;

namespace CampaignManager.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Type Type { get; set; }
        public Category Category { get; set; }
        public Subcategory Subcategory { get; set; }
        public decimal DefaultCost { get; set; }
    }
}