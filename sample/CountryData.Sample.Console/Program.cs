using CountryData.Standard;

/// <summary>
/// Main program class for demonstrating the use of the CountryData library.
/// </summary>
class Program
{
    /// <summary>
    /// Static instance of CountryHelper used throughout the program.
    /// </summary>
    private static readonly CountryHelper _helper = new CountryHelper();

    /// <summary>
    /// Entry point of the program.
    /// </summary>
    static void Main()
    {
        GetCountries();
        GetCountryByCode("US");
        GetCountryData();
        GetRegionsByCountryCode("US");
        GetCountryFlag("US");
        GetPhoneCodeByCountryShortCode("AF");
        GetCountryByPhoneCode("+233");


    }

    /// <summary>
    /// Retrieves a list of all countries and prints them to the console.
    /// </summary>
    static void GetCountries()
    {
        var countries = _helper.GetCountries();
        Console.WriteLine("Countries:");
        foreach (var country in countries)
        {
            Console.WriteLine(country);
        }
    }

    /// <summary>
    /// Retrieves the data for a given country code and prints it to the console.
    /// </summary>
    /// <param name="countryCode">The ISO country code.</param>
    static void GetCountryByCode(string countryCode)
    {
        var country = _helper.GetCountryByCode(countryCode);
        Console.WriteLine($"Country data for {countryCode}:");
        Console.WriteLine(country.CountryName);
    }

    /// <summary>
    /// Retrieves comprehensive data for all countries and prints it to the console.
    /// </summary>
    static void GetCountryData()
    {
        var countryData = _helper.GetCountryData();
        Console.WriteLine("Country data:");
        foreach (var data in countryData)
        {
            Console.WriteLine(data.CountryName);
        }
    }

    /// <summary>
    /// Retrieves the regions for a given country code and prints them to the console.
    /// </summary>
    /// <param name="countryCode">The ISO country code.</param>
    static void GetRegionsByCountryCode(string countryCode)
    {
        var regions = _helper.GetRegionByCountryCode(countryCode);
        Console.WriteLine($"Regions for {countryCode}:");
        foreach (var region in regions)
        {
            Console.WriteLine(region.Name);
        }
    }

    /// <summary>
    /// Retrieves the emoji flag for a given country short code and prints it to the console.
    /// </summary>
    /// <param name="shortCode">The country short code.</param>
    static void GetCountryFlag(string shortCode)
    {
        var flag = _helper.GetCountryEmojiFlag(shortCode);
        Console.WriteLine($"Flag for {shortCode}:");
        Console.WriteLine(flag);
    }



    /// <summary>
    /// Retrieves the phone code for a given country short code and prints it to the console.
    /// </summary>
    /// <param name="shortCode">The country short code.</param>
    static void GetPhoneCodeByCountryShortCode(string shortCode)
    {
        var phoneCode = _helper.GetPhoneCodeByCountryShortCode(shortCode);
        Console.WriteLine($"Phone code for {shortCode}:");
        Console.WriteLine(phoneCode);
    }

    /// <summary>
    /// Retrieves the country name for a given phone code and prints it to the console.
    /// </summary>
    /// <param name="phoneCode">The phone code.</param>
    static void GetCountryByPhoneCode(string phoneCode)
    {
        var countries = _helper.GetCountriesByPhoneCode(phoneCode);
        Console.WriteLine($"Countries for phone code {phoneCode}:");
        foreach (var country in countries)
        {
            Console.WriteLine(country.CountryName); 
        }
    }



}