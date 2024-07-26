using System.Collections.Generic;

namespace CountryData.Standard
{
    public class Country
    {
        public string CountryName { get; set; }
        public string PhoneCode { get; set; }
        public string CountryShortCode { get; set; }
        public string CountryFlag { get; set; }

        public List<Currency> Currency { get; set; }
        public List<Regions> Regions { get; set; }

    }
}
