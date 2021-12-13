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
        private const string strFileName = "CountryData.Standard.data.json";
        public CountryHelper()
         {          
            var json = GetJsonData(strFileName);
            _Countries = JsonConvert.DeserializeObject<List<Country>>(json);
        }


        private string GetJsonData(string path)
        {
            string json = "";
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(path))
            {
                var reader = new StreamReader(stream);
               json=  reader.ReadToEnd();

            }
            return json;
        }

        /// <summary>
        /// Returns All Country Data (Region, ShortCode, Country Name)
        /// that can be querried by Lambda Expressions
        /// </summary>
        /// <returns>IEnumerable<Country></returns>
        public IEnumerable<Country> GetCountryData()
        {
            return _Countries;
        }


        /// <summary>
        /// Returns a single Country Data by ShortCode
        /// </summary>
        /// <param name="ShortCode"></param>
        /// <returns>Country</returns>
        public Country GetCountryByCode(string ShortCode)
        {
            return _Countries.SingleOrDefault(c => c.CountryShortCode == ShortCode);
        }


         /// <summary>
        /// Selects Regions in a Particular Country
        /// </summary>
        /// <param name="ShortCode"></param>
        /// <returns>List<Regions> a list of regions</returns>
        public List<Regions> GetRegionByCountryCode(string ShortCode)
        {
            return _Countries.Where(x => x.CountryShortCode == ShortCode)
                              .Select(r=>r.Regions).FirstOrDefault()
                              .ToList();
        }

        /// <summary>
        /// Gets the list of all countries in the worlld
        /// </summary>
        /// <returns>IEnumerable<string> countries</returns>
        public IEnumerable<string> GetCountries() => _Countries.Select(c => c.CountryName);

    }
}
