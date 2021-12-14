using CountryData.Standard;

var countryHelper = new CountryHelper();


var countryData = countryHelper.GetCountryData().Take(10);
foreach (var countryItem in countryData)
{
    Console.WriteLine($"{countryItem.CountryName} ({countryItem.CountryShortCode}) has {countryItem.Regions.Count} regions");
}


var country = countryHelper.GetCountryByCode("GH");
Console.WriteLine($"{country.CountryName} ({country.CountryShortCode}) has {country.Regions.Count} regions");

