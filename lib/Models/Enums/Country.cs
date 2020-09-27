using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CampaignManager.Models
{
    public enum Country
    {
        Unknown,
        [Description("N/A")]
        NotApplicable,
        Afghanistan,
        Albania,
        Algeria,
        Andorra,
        Angola,
        [Description("Antigua & Barbuda")]
        AntiguaAndBarbuda,
        Argentina,
        Armenia,
        Australia,
        Austria,
        Azerbaijan,
        [Description("The Bahamas")]
        TheBahamas,
        Bahrain,
        Bangladesh,
        Barbados,
        Belarus,
        Belgium,
        Belize,
        Benin,
        Bhutan,
        Bolivia,
        [Description("Bosnia & Herzegovina")]
        BosniaAndHerzegovina,
        Botswana,
        Brazil,
        Brunei,
        Bulgaria,
        [Description("Burkina Faso")]
        BurkinaFaso,
        Burundi,
        Cambodia,
        Cameroon,
        Canada,
        [Description("Cape Verde")]
        CapeVerde,
        [Description("Central African Republic")]
        CentralAfricanRepublic,
        Chad,
        Chile,
        China,
        Colombia,
        Comoros,
        [Description("Republic of the Congo")]
        RepublicOfTheCongo,
        [Description("Democratic Republic of the Congo")]
        DemocraticRepublicOfTheCongo,
        [Description("Costa Rica")]
        CostaRica,
        [Description("Cote d'Ivoire")]
        CotedIvoire,
        Croatia,
        Cuba,
        Cyprus,
        [Description("Czech Republic")]
        CzechRepublic,
        Denmark,
        Djibouti,
        Dominica,
        [Description("Dominican Republic")]
        DominicanRepublic,
        [Description("East Timor (Timor-Leste)")]
        EastTimor,
        Ecuador,
        Egypt,
        [Description("El Salvador")]
        ElSalvador,
        [Description("Equatorial Guinea")]
        EquatorialGuinea,
        Eritrea,
        Estonia,
        Ethiopia,
        Fiji,
        Finland,
        France,
        Gabon,
        [Description("The Gambia")]
        TheGambia,
        Georgia,
        Germany,
        Ghana,
        Greece,
        Grenada,
        Guatemala,
        Guinea,
        [Description("Guinea-Bissau")]
        GuineaBissau,
        Guyana,
        Haiti,
        Honduras,
        Hungary,
        Iceland,
        India,
        Indonesia,
        Iran,
        Iraq,
        Ireland,
        Israel,
        Italy,
        Jamaica,
        Japan,
        Jordan,
        Kazakhstan,
        Kenya,
        Kiribati,
        [Description("North Korea")]
        NorthKorea,
        [Description("South Korea")]
        SouthKorea,
        Kosovo,
        Kuwait,
        Kyrgyzstan,
        Laos,
        Latvia,
        Lebanon,
        Lesotho,
        Liberia,
        Libya,
        Liechtenstein,
        Lithuania,
        Luxembourg,
        Macedonia,
        Madagascar,
        Malawi,
        Malaysia,
        Maldives,
        Mali,
        Malta,
        [Description("Marshall Islands")]
        MarshallIslands,
        Mauritania,
        Mauritius,
        Mexico,
        [Description("Federated States of Micronesia")]
        FederatedStatesOfMicronesia,
        Moldova,
        Monaco,
        Mongolia,
        Montenegro,
        Morocco,
        Mozambique,
        [Description("Myanmar (Burma)")]
        Myanmar,
        Namibia,
        Nauru,
        Nepal,
        Netherlands,
        [Description("New Zeland")]
        NewZealand,
        Nicaragua,
        Niger,
        Nigeria,
        Norway,
        Oman,
        Pakistan,
        Palau,
        Panama,
        [Description("Papua New Guinea")]
        PapuaNewGuinea,
        Paraguay,
        Peru,
        Philippines,
        Poland,
        Portugal,
        Qatar,
        Romania,
        Russia,
        Rwanda,
        [Description("Saint Kitts & Nevis")]
        SaintKittsAndNevis,
        [Description("Saint Luicia")]
        SaintLucia,
        [Description("Saint Vincent & the Grenadines")]
        SaintVincentAndTheGrenadines,
        Samoa,
        [Description("San Marino")]
        SanMarino,
        [Description("Sao Tome & Principe")]
        SaoTomeAndPrincipe,
        [Description("Saudi Arabia")]
        SaudiArabia,
        Senegal,
        Serbia,
        Seychelles,
        [Description("Sierra Leone")]
        SierraLeone,
        Singapore,
        Slovakia,
        Slovenia,
        [Description("Solomon Islands")]
        SolomonIslands,
        Somalia,
        [Description("South Africa")]
        SouthAfrica,
        [Description("South Sudan")]
        SouthSudan,
        Spain,
        [Description("Sri Lanka")]
        SriLanka,
        Sudan,
        Suriname,
        Swaziland,
        Sweden,
        Switzerland,
        Syria,
        Taiwan,
        Tajikistan,
        Tanzania,
        Thailand,
        Togo,
        Tonga,
        [Description("Trinidad & Tobago")]
        TrinidadAndTobago,
        Tunisia,
        Turkey,
        Turkmenistan,
        Tuvalu,
        Uganda,
        Ukraine,
        [Description("United Arab Emirates")]
        UnitedArabEmirates,
        [Description("United Kingdom")]
        UnitedKingdom,
        [Description("United States of America")]
        UnitedStatesOfAmerica,
        Uruguay,
        Uzbekistan,
        Vanuatu,
        [Description("Vatican City (Holy See)")]
        VaticanCity,
        Venezuela,
        Vietnam,
        Yemen,
        Zambia,
        Zimbabwe,
    }
}