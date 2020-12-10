using CampaignManager.Models.Enums;

namespace CampaignManager.App.Models
{
    public class CampaignEntityCostDTO
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public int CampaignId { get; set; }
        public decimal Cost { get; set; }
    }
}