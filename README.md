# :earth_africa: CountryData.Standard
[![Gitter](https://badges.gitter.im/CountryDataDotnet/community.svg)](https://gitter.im/CountryDataDotnet/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge).    
A simple cross platform offline .NET library for getting Global Country Data without making any HTTP calls.


| | |
|-|-|
| nuget downloads | [![](https://img.shields.io/nuget/dt/CountryData.Standard)](https://www.nuget.org/packages/CountryData.Standard) |
| builds | [![.NET](https://github.com/frankodoom/CountryData.Standard/actions/workflows/dotnet.yml/badge.svg?branch=master)](https://github.com/frankodoom/CountryData.Standard/actions/workflows/dotnet.yml) [![Join the chat at https://gitter.im/CountryDataDotnet/community](https://badges.gitter.im/CountryDataDotnet/community.svg)](https://gitter.im/CountryDataDotnet/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge) |



### Install Library
```cSharp
   PM> Install-Package CountryData.Standard -Version 1.0.1
```


### Initialize the Country data object

```cSharp
       //loads all Country Data via the constructor (You can initialize this once as a singleton)
       var helper = new CountryHelper();
```


### Get list of Countries 
```cSharp
       var countries = helper.GetCountries();
       foreach (var country in countries)
       {
        Console.WriteLine(country);
       }
```


### Get list of Regions in a Country by Country Code
```cSharp
       var regions = helper.GetRegionByCountryCode("GH");
       foreach (var region in regions)
       {
        Console.WriteLine(region.Name);
       }
```


### Using lambda for custom querries
#### `GetCountryData()` returns an `IEnumerable<Country>` which can be querried with Lambda for a more flexible usage.
```cSharp
      //example1
      var data = helper.GetCountryData();
       //get list of countries by their Names
      var countries = data.Select(c => c.CountryName).ToList();
       foreach (var country in countries)
       {
        Console.WriteLine(country);
       }
       
       
       //example 2
       data.Where(x => x.CountryShortCode == "US")
                              .Select(r=>r.Regions).FirstOrDefault()
                              .ToList();
```


### Comming Soon
* Support for more ISO Standard Country Data
* Support for ISO 3166 Country A3 Codes
* Support for Country Phone Code
* Country ShortCode Enums


```
The MIT License

Copyright (c) 2021 Accede.

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.
```
