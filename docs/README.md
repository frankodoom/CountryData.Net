

## CountryData.Standard Documentation


CountryData.Standard is a comprehensive library designed to provide seamless access to global country data for .NET applications. This robust package includes information such as:

- Country Names
- Regional Data
- National Flags
- Country Phone Codes

Our aim is to simplify the process of integrating global data into your applications, making it an ideal tool for developers who require international data. 

## Getting Started with CountryData.Standard

Integrating CountryData.Standard into your project is a straightforward process. You can add it to your application using either NuGet Package Manager or the .NET CLI.

### Using NuGet Package Manager

In the Package Manager Console, execute the following command:

```shell
Install-Package CountryData.Standard -Version 1.4.1
```

###  Using .NET CLI

Alternatively, you can use the .NET CLI. Run the following command in your terminal:

```shell
dotnet add package CountryData.Standard --version 1.4.1
```

These commands will download and install the latest stable version of CountryData.Standard, allowing you to access a wealth of global country data right in your .NET applications.


#### Initializing CountryHelper

To start using CountryData.Standard, you need to create an instance of the `CountryHelper` class. This object will provide you with access to all the country data available in the library. The `CountryHelper` class is responsible for fetching and managing country data, making it easy for you to retrieve the information you need.

To initialize the `CountryHelper` object, simply create a new instance of the class:
```csharp
var helper = new CountryHelper();
```
This object will serve as your gateway to the vast array of country data available in the library.


### Sample Code 

If you to see how to use the library in a console application, web API, or other types of projects, please refer to the [Sample Code](../sample//README.md) section below.



### GetCountryData() Method

The `GetCountryData()` method is a powerful tool that provides comprehensive data for all countries. It returns an `IEnumerable<Country>`, a collection containing detailed information about each country. This method is particularly useful for applications that require a complete set of global country data.

Here's the method signature in C#:

```csharp
IEnumerable<Country> GetCountryData();
```

Each `Country` object in the returned `IEnumerable<Country>` includes the following properties:

- `CountryName`: The full name of the country.
- `CountryShortCode`: The ISO 3166-1 alpha-2 country code.
- `Region`: The region in which the country is located.
- `CountryFlag`: The  flag of the country.
- `PhoneCode`: The international dialing code for the country.



### GetCountries() Method

The `GetCountries()` method is designed to fetch a comprehensive list of all countries. It returns an `IEnumerable<string>`, which includes the names of all countries available in the library. This makes it easy to iterate over the list and utilize the country names within your application.

Here's the method signature in C#:

```csharp
IEnumerable<string> GetCountries();
```

The returned `IEnumerable<string>` contains:
- Country Name



### GetCountryByCode (string  shortCode)

The `GetCountryByCode()` method is designed to fetch detailed data for a specific country using its `ISO 3166-1 alpha-2 code. This method returns a `Country` object, providing a wealth of information about the country, including its name, region, flag, and phone code.

Here's the method signature in C#:

```csharp
Country GetCountryByCode(string shortCode);
```

This method is particularly useful when you need detailed information about a specific country. Simply pass the country's ISO code as a string argument, and the method will return a `Country` object filled with relevant data.



### GetRegionByCountryCode(string shortCode)

The `GetRegionByCountryCode()` method is designed to fetch a list of regions within a specific country, using the country's ISO 3166-1 alpha-2 code. This method returns a `List<Region>`, with each `Region` object representing a distinct region within the specified country.

Here's the method signature in C#:

```csharp
List<Region> GetRegionByCountryCode(string shortCode);
```

This method is particularly useful for applications that need to display or analyze regional data within a specific country. Simply pass the country's ISO code as a string argument, and the method will return a list of `Region` objects, each containing the name of a region within the country.




### GetCountryEmojiFlag (string shortCode)

The `GetCountryEmojiFlag ()` method is designed to fetch the  flag of a specific country using its ISO 3166-1 alpha-2 code. This method provides a simple and effective way to visually represent countries in your application.

Here's the method signature in C#:

```csharp
string GetCountryFlag (string shortCode);
```

This method returns the em flag of the country corresponding to the provided ISO code. It's particularly useful when you need to display a country's flag in a user interface or in text-based communication.

The returned string contains:
- `Country Flag`: The emoji representation of the country's flag.



### GetPhoneCodeByCountryShortCode(string shortCode)

The `GetPhoneCodeByCountryShortCode()` method is designed to fetch the international dialing code (phone code) for a specific country using its ISO 3166-1 alpha-2 code. This method is particularly useful when you need to display or use the phone code of a specific country in your application.

Here's the method signature in C#:

```csharp
string GetPhoneCodeByCountryShortCode(string shortCode);
```

Simply pass the country's ISO code as a string argument, and the method will return a string containing the country's international dialing code.


### GetCountryByPhoneCode(string phoneCode)

The `GetCountryByPhoneCode()` method is designed to fetch detailed data for a specific country using its international dialing code (phone code). This method returns a `Country` object, providing a wealth of information about the country, including its name, region, flag, and ISO code.

Here's the method signature in C#:

```csharp
Country GetCountryByPhoneCode(string phoneCode);
```

This method is particularly useful when you have a phone code and need to retrieve the corresponding country's information. Simply pass the phone code as a string argument, and the method will return a `Country` object filled with relevant data.



