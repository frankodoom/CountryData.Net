using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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
            foreach (var country in _Countries)
            {
                country.CountryFlag = GetCountryEmojiFlag(country.CountryShortCode);
            }
        }

        /// <summary>
        ///  Read 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetJsonData(string path)
        {
            string json = "";
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(path))
            {
                var reader = new StreamReader(stream);
                json = reader.ReadToEnd();

            }
            return json;
        }

        /// <summary>
        /// Returns All Country Data (Region, ShortCode, Country Name)
        /// that can be querried by Lambda Expressions
        /// </summary>
        /// <returns>IEnumerable<Country></returns>
        public virtual IEnumerable<Country> GetCountryData()
        {
            return _Countries;
        }

        /// <summary>
        /// Returns a single Country Data by ShortCode
        /// </summary>
        /// <param name="ShortCode"></param>
        /// <returns>Country</returns>
        public Country GetCountryByCode(string shortCode)
        {
            return _Countries.SingleOrDefault(c => c.CountryShortCode == shortCode);
        }

        /// <summary>
        /// Gets the flag of the country, in the form of an emoji.
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public string GetCountryEmojiFlag(string shortCode)
        {
            return string.Concat(shortCode.ToUpper().Select(x => char.ConvertFromUtf32(x + 0x1F1E6 - 'A')));
        }

        /// <summary>
        /// Selects Regions in a Particular Country
        /// </summary>
        /// <param name="ShortCode"></param>
        /// <returns>List<Regions> a list of regions</returns>
        public List<Regions> GetRegionByCountryCode(string ShortCode)
        {
            return _Countries.Where(x => x.CountryShortCode == ShortCode)
                              .Select(r => r.Regions).FirstOrDefault()
                              .ToList();
        }

        /// <summary>
        /// Gets the list of all countries in the worlld
        /// </summary>
        /// <returns>IEnumerable<string> countries</returns>
        public IEnumerable<string> GetCountries() => _Countries.Select(c => c.CountryName);

        /// <summary>
        /// Returns a single Country's Phone Code by ShortCode
        /// </summary>
        /// <param name="shortCode"></param>
        /// <returns>string</returns>
        public string GetPhoneCodeByCountryShortCode(string shortCode)
        {
            var country = _Countries.SingleOrDefault(c => c.CountryShortCode == shortCode);
            return country?.PhoneCode;
        }

        /// <summary>
        /// Returns a single Country Data by PhoneCode
        /// </summary>
        /// <param name="phoneCode"></param>
        /// <returns>Country</returns>
        public IEnumerable<Country> GetCountryByPhoneCode(string phoneCode)
        {
            var Country = _Countries.Where(c => c.PhoneCode == phoneCode);
            return Country;
        }

        /// <summary>
        /// Retrieves all currency codes for a given country identified by its short code.
        /// </summary>
        /// <param name="shortCode">The short code of the country.</param>
        /// <returns>An IEnumerable of Currency objects associated with the specified country.</returns>
        public IEnumerable<Currency> GetCurrencyCodesByCountryCode(string shortCode)
        {
            return _Countries.Where(x => x.CountryShortCode == shortCode)
                             .SelectMany(c => c.Currency)
                             .ToList();
        }

        /// <summary>
        /// Retrieves a list of countries that use a specific currency code.
        /// </summary>
        /// <param name="currencyCode">The currency code to search for.</param>
        /// <returns>An IEnumerable of Country objects that use the specified currency code.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the country data is not initialized.</exception>
        public IEnumerable<Country> GetCountryByCurrencyCode(string currencyCode)
        {
            if (_Countries == null)
            {
                throw new InvalidOperationException("Country data is not initialized.");
            }

            return _Countries.Where(c => c.Currency != null && c.Currency.Exists(currency => currency.Code == currencyCode));
        }
    }
}
