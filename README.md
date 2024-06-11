
# :earth_africa: CountryData.Net
[![Gitter](https://badges.gitter.im/CountryDataDotnet/community.svg)](https://gitter.im/CountryDataDotnet/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)   
A simple cross-platform offline .NET library for getting Global Country Data without making any HTTP calls.


| | |
|-|-|
| nuget downloads | [![](https://img.shields.io/nuget/dt/CountryData.Standard)](https://www.nuget.org/packages/CountryData.Standard) |
| builds | ![.NET](https://github.com/frankodoom/CountryData.Net/actions/workflows/development-action.yml/badge.svg?branch=development) |
|code coverage|[![codecov](https://codecov.io/github/frankodoom/CountryData.Net/branch/development/graph/badge.svg?token=E79CY267AR)](https://codecov.io/github/frankodoom/CountryData.Net)
|code quality |[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=frankodoom_CountryData.Net&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=frankodoom_CountryData.Net)


### Features

- 🌍 Get global country data [CountryName, CountryPhone, Region, CountryFlag, PhoneCode ]
- 🏳️‍🌈 Get country data by ISO 3166 country code
- 🚩 Get country flag by ISO 3166 country code
- 🗺️ Get country region by ISO 3166 country code
- ☎️ Get country phone code by ISO 3166 country code

### Install Library
##### Package Manager
```cSharp
   PM> Install-Package CountryData.Standard -Version 1.4.1
```

##### .NET CLI
```cSharp
   > dotnet add package CountryData.Standard --version 1.4.1
```


### Usage

This production-grade package can be used with .NET Core Webapi, .NET console applications, .NET Maui, Xamarin, Blazor, and mobile apps. It is compatible with both .NET Core and .NET Framework projects.

For detailed instructions on how to use the library, please refer to our [documentation](./docs/README.md ).

For a quick start, you can check out the  `Simple code` folder   provided in the repository.




### Initialize the Country data object

```cSharp
       //loads all Country Data via the constructor (You can initialize this once as a singleton)
       var helper = new CountryHelper();
```


### Get list of Countries 
```cSharp
       var countries = helper.GetCountries();
       foreach (var country in countries) 
         Console.WriteLine(country);
```


### Get list of Regions in a Country by Country Code
```cSharp
       var regions = helper.GetRegionByCountryCode("GH");
       foreach (var region in regions)
         Console.WriteLine(region.Name);
```
### Using lambda for custom querries
#### `GetCountryData()` returns an `IEnumerable<Country>` which can be querried with Lambda for a more flexible usage.
```cSharp
      //example1
      var data = helper.GetCountryData();
       //get list of countries by their Names
      var countries = data.Select(c => c.CountryName).ToList();
       foreach (var country in countries)
         Console.WriteLine(country);
       
      
       //example 2
       data.Where(x => x.CountryShortCode == "US")
                              .Select(r=>r.Regions).FirstOrDefault()
                              .ToList();
```


This example demonstrates how to retrieve countries with a specific phone code using the `GetCountriesByPhoneCode` method. In this case, we're fetching all countries with the phone code "+1".

```csharp
var countriesWithPhoneCode = helper.GetCountriesByPhoneCode("+233");
foreach (var country in countriesWithPhoneCode)
{
    Console.WriteLine(country.NameCountryName);
}

```

## ISO-3166-1 country codes

For a list of supported ISO-3166-1 country codes, PhoneCode, Flags, ISO and , Unicode  please refer to the [Country Details](./CountryData/CountryDetails.md) file.


## Contributing

Contributions are welcome! Please see our [Contributing Guide](CONTRIBUTING.md) for more details.Creating a `Code of Conduct` for your project involves defining the standards of behavior expected from contributors and maintainers. This document helps ensure that the community around your project is welcoming and collaborative. Here's a basic template you can use and customize for your project:


### Comming Soon
* Support for more ISO Standard Country Data
* Support for ISO 3166 Country A3 Codes
* Country ShortCode Enums 



## License

This project is licensed under the terms of the [LICENSE](LICENSE).
