using System;
using System.ComponentModel;

namespace CampaignManager.Models
{
    public enum Status
    {
        Unknown,
        [Description("N/A")]
        NotApplicable,
        Destroyed,
        Disabled,
        Operational
    }
}