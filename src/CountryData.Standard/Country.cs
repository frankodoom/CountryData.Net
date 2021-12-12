using CountryData.Standard;
using System;
using System.Collections.Generic;

namespace CountryData.Standard
{
    public class Country
    {
        public string CountryName { get; set; }
        public string CountryShortCode { get; set; }
        public List<Regions> Regions { get; set; }
    }
}
