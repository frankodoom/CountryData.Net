

## CountryData.Standard Documentation

Welcome to the CountryData.Standard documentation. This package provides easy access to global country data, including names, regions, and flags, directly from your.NET applications.

### Getting Started

#### Installation

To get started with CountryData.Standard, you can install it via NuGet:

```shell
Install-Package CountryData.Standard -Version 1.3.0
```

Or using the.NET CLI:

```shell
dotnet add package CountryData.Standard --version 1.3.0
```

### Features

- Retrieve a list of all countries.
- Fetch detailed data for a specific country by its ISO code.
- Obtain regions within a country.
- Display the emoji flag for any country.

### Usage

#### Initializing CountryHelper

Before using the features of CountryData.Standard, you must initialize the `CountryHelper` class:

```csharp
var helper = new CountryHelper();
```

#### Examples

##### Console Application Example

Refer to the [Console Sample Code](./sample/CountryData.Sample.Console/Program.cs) for a complete example of using CountryData.Standard in a console application. This sample demonstrates how to retrieve and display various country data.

##### Web API Example

For integrating CountryData.Standard into a Web API, see the [Web API Sample Code](./sample/CountryData.Sample.WebApi/Controllers/CountryController.cs). This example shows how to create endpoints that return country data based on user requests.

### API Reference

#### CountryHelper Class

##### Methods

###### GetCountries()

Retrieves a list of all countries.

```csharp
IEnumerable<string> GetCountries();
```

###### GetCountryByCode(string shortCode)

Fetches detailed data for a specific country by its ISO code.

```csharp
Country GetCountryByCode(string shortCode);
```

###### GetCountryData()

Returns comprehensive data for all countries.

```csharp
IEnumerable<Country> GetCountryData();
```

###### GetRegionByCountryCode(string shortCode)

Obtains regions within a country.

```csharp
List<Regions> GetRegionByCountryCode(string shortCode);
```

###### GetCountryEmojiFlag(string shortCode)

Displays the emoji flag for any country.

```csharp
string GetCountryEmojiFlag(string shortCode);
```

######  GetPhoneCodeByCountryShortCode(string shortCode) 

Returns a single Country's Phone Code by ShortCode

```csharp

 string GetPhoneCodeByCountryShortCode(string shortCode)

```


######  GetCountryByPhoneCode(string phoneCode)

 Returns a single Country Data by PhoneCode


```csharp
 Country GetCountryByPhoneCode(string phoneCode)

```



