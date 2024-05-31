using CountryData.Standard;
using Microsoft.AspNetCore.Mvc;

namespace CountryData.Sample.Web.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private readonly CountryHelper _helper;

        public CountryController(CountryHelper helper)
        {
            _helper = helper;
        }




        /// <summary>
        /// Retrieves a list of all countries.
        /// </summary>
        /// <returns>A list of all countries. If no countries are found, a NotFound result is returned.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Country>), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetCountries()
        {
            var countries = _helper.GetCountries();
            if (countries == null)
            {
                return NotFound();
            }
            return Ok(countries);
        }



        /// <summary>
        /// Retrieves the country data for a given country code.
        /// </summary>
        /// <param name="countryCode">The ISO country code.</param>
        /// <returns>The data for the specified country. If no data is found, a NotFound result is returned.</returns>
        [HttpGet("country")]
        [ProducesResponseType(typeof(Country), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetCountryByCode([FromQuery] string countryCode)
        {
            var country = _helper.GetCountryByCode(countryCode);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }


        /// <summary>
        /// Returns comprehensive data for all countries.
        /// </summary>
        /// <returns>
        /// A collection of country data, including short codes and regions. 
        /// If no data is found, a NotFound result is 

        [HttpGet("countries")]
        [ProducesResponseType(typeof(IEnumerable<Country>), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetCountryData()
        {
            var country = _helper.GetCountryData();
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }



        /// <summary>
        /// Retrieves the regions for a given country code.
        /// </summary>
        /// <param name="countryCode">The ISO country code.</param>
        /// <returns>A list of regions for the specified country. If no regions are found, a NotFound result is returned.</returns>
        [HttpGet("regions")]
        [ProducesResponseType(typeof(IEnumerable<Regions>), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetRegionsByCountryCode([FromQuery] string countryCode)
        {
            var regions = _helper.GetRegionByCountryCode(countryCode);
            if (regions == null)
            {
                return NotFound();
            }
            return Ok(regions);
        }


        /// <summary>
        /// Retrieves the emoji flag for a given country short code.
        /// </summary>
        /// <param name="shortCode">The short code of the country.</param>
        /// <returns>The emoji flag for the specified country. If no flag is found, a NotFound result is returned.</returns>
        [HttpGet("flag")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetCountryFlag([FromQuery] string countryCode)
        {
            var flag = _helper.GetCountryEmojiFlag(countryCode);
            if (flag == null)
            {
                return NotFound();
            }
            return Ok(flag);
        }


        /// <summary>
        /// Retrieves the phone code for a given country short code.
        /// </summary>
        /// <param name="shortCode">The short code of the country.</param>
        /// <returns>The phone code for the specified country. If no phone code is found, a NotFound result is returned.</returns>
        [HttpGet("phoneCodeByShortCode")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetPhoneCodeByCountryShortCode([FromQuery] string countryCode)
        {
            var phoneCode = _helper.GetPhoneCodeByCountryShortCode(countryCode);
            if (phoneCode == null)
            {
                return NotFound();
            }
            return Ok(phoneCode);
        }

        /// <summary>
        /// Retrieves the country data for a given phone code.
        /// </summary>
        /// <param name="phoneCode">The phone code of the country.</param>
        /// <returns>The data for the specified country. If no data is found, a NotFound result is returned.</returns>
        [HttpGet("countryByPhoneCode")]
        [ProducesResponseType(typeof(Country), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetCountryByPhoneCode([FromQuery] string phoneCode)
        {
            var countryDataByPhoneCode = _helper.GetCountryByPhoneCode(phoneCode);
            if (countryDataByPhoneCode == null)
            {
                return NotFound();
            }
            return Ok(countryDataByPhoneCode);
        }




    }
}