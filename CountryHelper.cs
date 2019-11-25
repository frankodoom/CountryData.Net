using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CountryData.Standard
{
    public class CountryHelper
    {
       private readonly IEnumerable<Country> _Countries;
       public CountryHelper()
       {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data.json");
            var json = File.ReadAllText(path);
            _Countries = JsonConvert.DeserializeObject<List<Country>>(json);
        }


        public IEnumerable<Country> GetCountryData()
        {
            return _Countries;
        }


        /// <summary>
        /// Returns A particular Country and its Regions by Its ShortCoded
        /// </summary>
        /// <param name="ShortCode"></param>
        /// <returns>IEnumerable<Country></returns>
        public IEnumerable<Country> GetCountry(string ShortCode)
        {
            return _Countries.Where(x => x.CountryShortCode == ShortCode);
        }


        /// <summary>
        /// Select Regions in a Particular Country
        /// </summary>
        /// <param name="ShortCode"></param>
        /// <returns>List<Regions> a list of regions</returns>
        public List<Regions> GetRegionByCountryCode(string ShortCode)
        {
            return _Countries.Where(x => x.CountryShortCode == ShortCode)
                              .Select(r=>r.Regions).FirstOrDefault()
                              .ToList();
        }


    }
}
