using CountryData.Standard;

var countryHelper = new CountryHelper();


var countryData = countryHelper.GetCountryData().Take(10);
foreach (var country in countryData)
{
    Console.WriteLine($"{country.CountryName} ({country.CountryShortCode}) has {country.Regions.Count} regions");
}


var countryByCode = countryHelper.GetCountry("GHA").ToList();
foreach (var country in countryByCode)
{
    Console.WriteLine($"{country.CountryName} ({country.CountryShortCode}) has {country.Regions.Count} regions");
}
