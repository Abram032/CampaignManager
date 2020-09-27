using System;
using System.ComponentModel;

namespace CampaignManager.Models
{
    public enum Category
    {
        Unknown,
        Airplane,
        Helicopters,
        Vehicle,
        Ship,
        [Description("Air Defence")]
        AirDefence,
        Armament,
        Static,
        Fuel
    }
}