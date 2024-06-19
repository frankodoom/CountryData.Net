
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

CountryData.Standard is a robust, production-grade package designed for a wide range of .NET applications. Whether you're developing a .NET Core Web API, a console application, a .NET MAUI or Xamarin app, a Blazor project, or a mobile app, this library is built to seamlessly integrate with your project. 

To get started quickly, check out our [Sample Code](./sample/README.md). This section provides practical examples of how to use the library in various types of projects.

For more detailed instructions and comprehensive information about the library, please refer to our [Documentation](./docs/README.md). This resource offers in-depth guidance on how to effectively use the CountryData.Standard library in your projects.



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


This example demonstrates how to retrieve a country with a specific phone code using the `GetCountryByPhoneCode` method. In this case, we're fetching the country with the phone code "+233".

```csharp
var CountryName = helper.GetCountryByPhoneCode("+233");
Console.WriteLine(CountryName);
```


### ISO-3166-1 country codes

For a list of supported ISO-3166-1 country codes, PhoneCode, Flags, ISO and , Unicode  please refer to the [Country Details](./CountryData/CountryDetails.md) file.



### Contributing

Contributions are welcome! We value your input and want to make contributing to this project as easy and transparent as possible. Please see our [Contributing Guide](CONTRIBUTING.md) for more details.

### Code of Conduct

We are committed to fostering a welcoming and respectful community for everyone. Our `Code of Conduct` outlines the standards of behavior expected from contributors and maintainers. This document helps ensure that the community around our project is inclusive and collaborative. Please refer to our [code of conduct](CODE_OF_CONDUCT.md)   for more information.


### Comming Soon
* Support for more ISO Standard Country Data
* Support for ISO 3166 Country A3 Codes
* Country ShortCode Enums 



### License

This project is licensed under the terms of the [LICENSE](LICENSE).
