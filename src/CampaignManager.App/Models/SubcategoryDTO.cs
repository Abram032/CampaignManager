using CampaignManager.Models.Enums;

namespace CampaignManager.Models
{
    public class SubcategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
}