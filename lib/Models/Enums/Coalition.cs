using System;
using System.ComponentModel;

namespace CampaignManager.Models
{
    public enum Coalition
    {
        Unknown,
        [Description("N/A")]
        NotApplicable,
        Civilian,
        White,
        Blue,
        Red
    }
}