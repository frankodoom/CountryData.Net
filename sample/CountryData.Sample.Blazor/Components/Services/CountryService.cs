
using CountryData.Standard;

namespace CountryData.Sample.Blazor.Components.Services
{
    /// <summary>
    /// Service for accessing country data.
    /// </summary>
    public class CountryService
    {
        private readonly CountryHelper _helper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CountryService"/> class.
        /// </summary>
        /// <param name="helper">The country helper instance.</param>
        public CountryService(CountryHelper helper)
        {
            _helper = helper;
        }

        /// <summary>
        /// Gets the flag of a country by its country code.
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <returns>The country flag as a string.</returns>

        public string GetCountryFlag(string countryCode)
        {
            var countryFlag = _helper.GetCountryEmojiFlag(countryCode);

            if (string.IsNullOrEmpty(countryFlag))
            {

                return "No flag found";
            }

            return countryFlag;
        }


        /// <summary>
        /// Gets all countries.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of countries.</returns>
        public Task<IEnumerable<Country>> GetCountries()
        {
            var allCountries = _helper.GetCountryData();
            return Task.FromResult(allCountries);
        }

        /// <summary>
        /// Gets the country code by the country name.
        /// </summary>
        /// <param name="countryName">The country name.</param>
        /// <returns>The country code as a string.</returns>
        public string GetCountryCode(string countryName)
        {
            var country = _helper.GetCountryData()
                .FirstOrDefault(c => c.CountryName.Equals(countryName, StringComparison.OrdinalIgnoreCase));

            return country?.CountryShortCode;
        }

        /// <summary>
        /// Gets the country data by its country code.
        /// </summary>
        /// <param name="countryCode">The country code.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the country data.</returns>
        public Task<Country> GetCountryByCode(string countryCode)
        {
            var Country = _helper.GetCountryData()
                .FirstOrDefault(c => c.CountryShortCode.Equals(countryCode, StringComparison.OrdinalIgnoreCase));

            return Task.FromResult(Country);
        }

        /// <summary>
        /// Gets the country data by its phone code.
        /// </summary>
        /// <param name="phoneCode">The phone code.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the country data.</returns>
        public async Task<Country> GetCountryByPhoneCode(string phoneCode)
        {
            var country = _helper.GetCountryData()
                .FirstOrDefault(c => c.PhoneCode.Equals(phoneCode, StringComparison.OrdinalIgnoreCase));

            return await Task.FromResult(country);
        }
    }
}
