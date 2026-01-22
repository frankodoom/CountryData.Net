
using CountryData.Standard;

/// <summary>
/// Main program class for demonstrating the use of the CountryData library.
/// </summary>
public static class Program
{
    /// <summary>
    /// Static instance of CountryHelper used throughout the program.
    /// </summary>
    private static readonly CountryHelper _helper = new CountryHelper();


    /// <summary>
    /// Entry point of the program.
    /// </summary>
    public static void Main()
    {
        GetCountries();
        GetCountryByCode("US");
        GetCountryData();
        GetRegionsByCountryCode("US");
        GetCountryFlag("US");
        GetPhoneCodeByCountryShortCode("AF");
        GetCountryByPhoneCode("+233");
        GetCurrencyCodesByCountryCode("US");
        GetCountryByCurrencyCode("GHS");
        GetCountryCode("Ghana");
        GetAllCurrencyCodesByCountryCode();


    }

    /// <summary>
    /// Retrieves a list of all countries and prints them to the console.
    /// </summary>
    private static void GetCountries()
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
    private static void GetCountryByCode(string countryCode)
    {
        var country = _helper.GetCountryByCode(countryCode);
        Console.WriteLine($"Country data for {countryCode}:");
        Console.WriteLine(country.CountryName);
    }

    /// <summary>
    /// Retrieves comprehensive data for all countries and prints it to the console.
    /// </summary>
    private static void GetCountryData()
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
    private static void GetRegionsByCountryCode(string countryCode)
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
    private static void GetCountryFlag(string shortCode)
    {
        var flag = _helper.GetCountryEmojiFlag(shortCode);
        Console.WriteLine($"Flag for {shortCode}:");
        Console.WriteLine(flag);
    }

    /// <summary>
    /// Retrieves the phone code for a given country short code and prints it to the console.
    /// </summary>
    /// <param name="shortCode">The country short code.</param>
    private static void GetPhoneCodeByCountryShortCode(string shortCode)
    {
        var phoneCode = _helper.GetPhoneCodeByCountryShortCode(shortCode);
        Console.WriteLine($"Phone code for {shortCode}:");
        Console.WriteLine(phoneCode);
    }

    /// <summary>
    /// Retrieves the country name for a given phone code and prints it to the console.
    /// </summary>
    /// <param name="phoneCode">The phone code.</param>
    private static void GetCountryByPhoneCode(string phoneCode)
    {
        var countries = _helper.GetCountryByPhoneCode(phoneCode);
        Console.WriteLine($"Country for phone code {phoneCode}:");
        foreach (var country in countries)
        {
            Console.WriteLine(country.CountryName);
        }
    }


    /// <summary>
    /// Retrieves and prints the currency codes for a given country code.
    /// </summary>
    /// <param name="shortCode">The short country code to look up currency codes for.</param>
    private static void GetCurrencyCodesByCountryCode(string shortCode)
    {
        var currencyCodes = _helper.GetCurrencyCodesByCountryCode(shortCode);
        Console.WriteLine($"Currency codes for {shortCode}:");
        foreach (var currencyCode in currencyCodes)
        {
            Console.WriteLine(currencyCode.Code);
        }
    }



    /// <summary>
    /// Retrieves and prints the countries that use a given currency code.
    /// </summary>
    /// <param name="currencyCode">The currency code to look up countries for.</param>
    private static void GetCountryByCurrencyCode(string currencyCode)
    {
        var countries = _helper.GetCountryByCurrencyCode(currencyCode);
        Console.WriteLine($"Countries for currency code {currencyCode}:");
        foreach (var country in countries)
        {
            Console.WriteLine(country.CountryName);
        }
    }



    /// <summary>
    /// Retrieves the country code for a given country name and prints it to the console.
    /// </summary>
    /// <param name="countryName">The name of the country.</param>
    private static void GetCountryCode(string countryName)
    {
        using var manager = new CountryExtensions();
        var result = manager.GetCountryCode(countryName);
        Console.WriteLine($"Country code for {countryName} is {result} ");
    }


    /// <summary>
    ///  Prints the currency codes for all countries to the console.
    /// </summary>
    /// <param name="shortCode">The short country code to look up currency codes for.</param>

    public static void GetAllCurrencyCodesByCountryCode()
    {

        var countryData = _helper.GetCountryData();
        foreach (var data in countryData)
        {
            var currencyCodes = _helper.GetCurrencyCodesByCountryCode(data.CountryShortCode);
            Console.WriteLine($"Currency codes for {data.CountryShortCode}:");
            foreach (var currencyCode in currencyCodes)
            {
                Console.WriteLine($"{currencyCode.Name}" + $"{currencyCode.Code}");
            }


        }


    }

}



