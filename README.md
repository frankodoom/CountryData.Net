<img src="./Assets/logo.png" alt="logo" height="200" width="200">



# :earth_africa: CountryData.Net
[![Gitter](https://badges.gitter.im/CountryDataDotnet/community.svg)](https://gitter.im/CountryDataDotnet/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)   
A simple cross-platform offline .NET library for getting Global Country Data without making any HTTP calls.


| | |
|-|-|
| nuget downloads | [![](https://img.shields.io/nuget/dt/CountryData.Standard)](https://www.nuget.org/packages/CountryData.Standard) |
| builds | ![.NET](https://github.com/frankodoom/CountryData.Net/actions/workflows/development-action.yml/badge.svg?branch=development) |
|code coverage|[![codecov](https://codecov.io/github/frankodoom/CountryData.Net/branch/development/graph/badge.svg?token=E79CY267AR)](https://codecov.io/github/frankodoom/CountryData.Net)



### Features

- 📄 Load country data from a JSON file
- 🌍 Get all country data
- 🏳️‍🌈 Get a single country's data by its short code
- 🚩 Get a country's emoji flag by its short code
- 🗺️ Get regions of a country by its short code
- 🌎 Get a list of all country names
- ☎️ Get a country's phone code by its short code
- 🌐 Get a country's data by its phone code

### Install Library
##### Package Manager
```cSharp
   PM> Install-Package CountryData.Standard -Version 1.3.0
```

##### .NET CLI
```cSharp
   > dotnet add package CountryData.Standard --version 1.3.0
```


### Usage

This production-grade package can be used with .NET Core Webapi, .NET console applications, .NET Maui, Xamarin, Blazor, and mobile apps. It is compatible with both .NET Core and .NET Framework projects.

For detailed instructions on how to use the library, please refer to our [documentation](../CountryData.Net/docs/README.md).

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


####  List of supported ISO-3166-1 country codes, their codepoint pairs and Emoji Flags.

|ISO|Emoji|Unicode|Name|PhoneCode 
|--- |--- |--- |--- |------|
|AD|🇦🇩|U+1F1E6 U+1F1E9|Andorra| +376
|AE|🇦🇪|U+1F1E6 U+1F1EA|United Arab Emirates| +271
|AF|🇦🇫|U+1F1E6 U+1F1EB|Afghanistan|+93
|AG|🇦🇬|U+1F1E6 U+1F1EC|Antigua and Barbuda| +1268
|AI|🇦🇮|U+1F1E6 U+1F1EE|Anguilla|+1264
|AL|🇦🇱|U+1F1E6 U+1F1F1|Albania| +355
|AM|🇦🇲|U+1F1E6 U+1F1F2|Armenia|+374
|AO|🇦🇴|U+1F1E6 U+1F1F4|Angola| +244
|AQ|🇦🇶|U+1F1E6 U+1F1F6|Antarctica| +672
|AR|🇦🇷|U+1F1E6 U+1F1F7|Argentina| +54
|AS|🇦🇸|U+1F1E6 U+1F1F8|American Samoa| +1684
|AT|🇦🇹|U+1F1E6 U+1F1F9|Austria| +43
|AU|🇦🇺|U+1F1E6 U+1F1FA|Australia| +61
|AW|🇦🇼|U+1F1E6 U+1F1FC|Aruba|+297
|AX|🇦🇽|U+1F1E6 U+1F1FD|Åland Islands|+358
|AZ|🇦🇿|U+1F1E6 U+1F1FF|Azerbaijan| +994
|BA|🇧🇦|U+1F1E7 U+1F1E6|Bosnia and Herzegovina| +387
|BB|🇧🇧|U+1F1E7 U+1F1E7|Barbados| +1246
|BD|🇧🇩|U+1F1E7 U+1F1E9|Bangladesh| +880
|BE|🇧🇪|U+1F1E7 U+1F1EA|Belgium| +32
|BF|🇧🇫|U+1F1E7 U+1F1EB|Burkina Faso| +226
|BG|🇧🇬|U+1F1E7 U+1F1EC|Bulgaria| +359
|BH|🇧🇭|U+1F1E7 U+1F1ED|Bahrain| +973
|BI|🇧🇮|U+1F1E7 U+1F1EE|Burundi| +257
|BJ|🇧🇯|U+1F1E7 U+1F1EF|Benin| +229
|BL|🇧🇱|U+1F1E7 U+1F1F1|Saint Barthélemy| +590
|BM|🇧🇲|U+1F1E7 U+1F1F2|Bermuda| +1441
|BN|🇧🇳|U+1F1E7 U+1F1F3|Brunei Darussalam| +673
|BO|🇧🇴|U+1F1E7 U+1F1F4|Bolivia| +591
|BQ|🇧🇶|U+1F1E7 U+1F1F6|Bonaire, Sint Eustatius and Saba| +599
|BR|🇧🇷|U+1F1E7 U+1F1F7|Brazil| +55
|BS|🇧🇸|U+1F1E7 U+1F1F8|Bahamas| +1242
|BT|🇧🇹|U+1F1E7 U+1F1F9|Bhutan| +975
|BV|🇧🇻|U+1F1E7 U+1F1FB|Bouvet Island| +47
|BW|🇧🇼|U+1F1E7 U+1F1FC|Botswana| +267
|BY|🇧🇾|U+1F1E7 U+1F1FE|Belarus| +375
|BZ|🇧🇿|U+1F1E7 U+1F1FF|Belize| +501
|CA|🇨🇦|U+1F1E8 U+1F1E6|Canada| +1
|CC|🇨🇨|U+1F1E8 U+1F1E8|Cocos (Keeling) Islands| +61
|CD|🇨🇩|U+1F1E8 U+1F1E9|Congo| +243
|CF|🇨🇫|U+1F1E8 U+1F1EB|Central African Republic| +236
|CG|🇨🇬|U+1F1E8 U+1F1EC|Congo| +242
|CH|🇨🇭|U+1F1E8 U+1F1ED|Switzerland| +41
|CI|🇨🇮|U+1F1E8 U+1F1EE|Côte D'Ivoire| +225
|CK|🇨🇰|U+1F1E8 U+1F1F0|Cook Islands| +682
|CL|🇨🇱|U+1F1E8 U+1F1F1|Chile| +56
|CM|🇨🇲|U+1F1E8 U+1F1F2|Cameroon| +237
|CN|🇨🇳|U+1F1E8 U+1F1F3|China| +86
|CO|🇨🇴|U+1F1E8 U+1F1F4|Colombia| +57
|CR|🇨🇷|U+1F1E8 U+1F1F7|Costa Rica| +506
|CU|🇨🇺|U+1F1E8 U+1F1FA|Cuba| +53
|CV|🇨🇻|U+1F1E8 U+1F1FB|Cape Verde| +238
|CW|🇨🇼|U+1F1E8 U+1F1FC|Curaçao| +599
|CX|🇨🇽|U+1F1E8 U+1F1FD|Christmas Island| +61
|CY|🇨🇾|U+1F1E8 U+1F1FE|Cyprus| +357
|CZ|🇨🇿|U+1F1E8 U+1F1FF|Czech Republic| +420
|DE|🇩🇪|U+1F1E9 U+1F1EA|Germany| +49
|DJ|🇩🇯|U+1F1E9 U+1F1EF|Djibouti| +253
|DK|🇩🇰|U+1F1E9 U+1F1F0|Denmark|+45
|DM|🇩🇲|U+1F1E9 U+1F1F2|Dominica| +1767
|DO|🇩🇴|U+1F1E9 U+1F1F4|Dominican Republic| +1849
|DZ|🇩🇿|U+1F1E9 U+1F1FF|Algeria| +213
|EC|🇪🇨|U+1F1EA U+1F1E8|Ecuador| +593
|EE|🇪🇪|U+1F1EA U+1F1EA|Estonia| +372
|EG|🇪🇬|U+1F1EA U+1F1EC|Egypt| +20
|EH|🇪🇭|U+1F1EA U+1F1ED|Western Sahara| +212
|ER|🇪🇷|U+1F1EA U+1F1F7|Eritrea| +291
|ES|🇪🇸|U+1F1EA U+1F1F8|Spain| +34
|ET|🇪🇹|U+1F1EA U+1F1F9|Ethiopia| +251
|FI|🇫🇮|U+1F1EB U+1F1EE|Finland| +358
|FJ|🇫🇯|U+1F1EB U+1F1EF|Fiji| +679
|FK|🇫🇰|U+1F1EB U+1F1F0|Falkland Islands (Malvinas)| +500
|FM|🇫🇲|U+1F1EB U+1F1F2|Micronesia| +691
|FO|🇫🇴|U+1F1EB U+1F1F4|Faroe Islands| +298
|FR|🇫🇷|U+1F1EB U+1F1F7|France| +33
|GA|🇬🇦|U+1F1EC U+1F1E6|Gabon| +241
|GB|🇬🇧|U+1F1EC U+1F1E7|United Kingdom| +44
|GD|🇬🇩|U+1F1EC U+1F1E9|Grenada| +1473
|GE|🇬🇪|U+1F1EC U+1F1EA|Georgia| +995
|GF|🇬🇫|U+1F1EC U+1F1EB|French Guiana| +594
|GG|🇬🇬|U+1F1EC U+1F1EC|Guernsey| +44
|GH|🇬🇭|U+1F1EC U+1F1ED|Ghana| +233
|GI|🇬🇮|U+1F1EC U+1F1EE|Gibraltar| +350
|GL|🇬🇱|U+1F1EC U+1F1F1|Greenland| +299
|GM|🇬🇲|U+1F1EC U+1F1F2|Gambia| +220
|GN|🇬🇳|U+1F1EC U+1F1F3|Guinea| +224
|GP|🇬🇵|U+1F1EC U+1F1F5|Guadeloupe| +590
|GQ|🇬🇶|U+1F1EC U+1F1F6|Equatorial Guinea| +240
|GR|🇬🇷|U+1F1EC U+1F1F7|Greece| +30
|GS|🇬🇸|U+1F1EC U+1F1F8|South Georgia| +500
|GT|🇬🇹|U+1F1EC U+1F1F9|Guatemala| +502
|GU|🇬🇺|U+1F1EC U+1F1FA|Guam| +1671
|GW|🇬🇼|U+1F1EC U+1F1FC|Guinea-Bissau| +245
|GY|🇬🇾|U+1F1EC U+1F1FE|Guyana| +592
|HK|🇭🇰|U+1F1ED U+1F1F0|Hong Kong| +852
|HM|🇭🇲|U+1F1ED U+1F1F2|Heard Island and Mcdonald Islands| +672
|HN|🇭🇳|U+1F1ED U+1F1F3|Honduras| +504
|HR|🇭🇷|U+1F1ED U+1F1F7|Croatia| +385
|HT|🇭🇹|U+1F1ED U+1F1F9|Haiti| +509
|HU|🇭🇺|U+1F1ED U+1F1FA|Hungary| +36
|ID|🇮🇩|U+1F1EE U+1F1E9|Indonesia| +62
|IE|🇮🇪|U+1F1EE U+1F1EA|Ireland| +353
|IL|🇮🇱|U+1F1EE U+1F1F1|Israel| +972
|IM|🇮🇲|U+1F1EE U+1F1F2|Isle of Man| +44
|IN|🇮🇳|U+1F1EE U+1F1F3|India| +91
|IO|🇮🇴|U+1F1EE U+1F1F4|British Indian Ocean Territory| +246
|IQ|🇮🇶|U+1F1EE U+1F1F6|Iraq| +964
|IR|🇮🇷|U+1F1EE U+1F1F7|Iran| +98
|IS|🇮🇸|U+1F1EE U+1F1F8|Iceland| +354
|IT|🇮🇹|U+1F1EE U+1F1F9|Italy| +39
|JE|🇯🇪|U+1F1EF U+1F1EA|Jersey| +44
|JM|🇯🇲|U+1F1EF U+1F1F2|Jamaica|+1876
|JO|🇯🇴|U+1F1EF U+1F1F4|Jordan| +962
|JP|🇯🇵|U+1F1EF U+1F1F5|Japan| +81
|KE|🇰🇪|U+1F1F0 U+1F1EA|Kenya| +254
|KG|🇰🇬|U+1F1F0 U+1F1EC|Kyrgyzstan| +996
|KH|🇰🇭|U+1F1F0 U+1F1ED|Cambodia| +855
|KI|🇰🇮|U+1F1F0 U+1F1EE|Kiribati| +686
|KM|🇰🇲|U+1F1F0 U+1F1F2|Comoros| +269
|KN|🇰🇳|U+1F1F0 U+1F1F3|Saint Kitts and Nevis| +1869
|KP|🇰🇵|U+1F1F0 U+1F1F5|North Korea| +850
|KR|🇰🇷|U+1F1F0 U+1F1F7|South Korea| +82
|KW|🇰🇼|U+1F1F0 U+1F1FC|Kuwait| +965
|KY|🇰🇾|U+1F1F0 U+1F1FE|Cayman Islands| +1345
|KZ|🇰🇿|U+1F1F0 U+1F1FF|Kazakhstan| +77
|LA|🇱🇦|U+1F1F1 U+1F1E6|Lao People's Democratic Republic| +856
|LB|🇱🇧|U+1F1F1 U+1F1E7|Lebanon| +961
|LC|🇱🇨|U+1F1F1 U+1F1E8|Saint Lucia| +1758
|LI|🇱🇮|U+1F1F1 U+1F1EE|Liechtenstein| +423
|LK|🇱🇰|U+1F1F1 U+1F1F0|Sri Lanka| +94
|LR|🇱🇷|U+1F1F1 U+1F1F7|Liberia| +231
|LS|🇱🇸|U+1F1F1 U+1F1F8|Lesotho| +266
|LT|🇱🇹|U+1F1F1 U+1F1F9|Lithuania| +370
|LU|🇱🇺|U+1F1F1 U+1F1FA|Luxembourg| +352
|LV|🇱🇻|U+1F1F1 U+1F1FB|Latvia| +371
|LY|🇱🇾|U+1F1F1 U+1F1FE|Libya| +218
|MA|🇲🇦|U+1F1F2 U+1F1E6|Morocco| +212
|MC|🇲🇨|U+1F1F2 U+1F1E8|Monaco| +377
|MD|🇲🇩|U+1F1F2 U+1F1E9|Moldova| +373
|ME|🇲🇪|U+1F1F2 U+1F1EA|Montenegro| +382
|MF|🇲🇫|U+1F1F2 U+1F1EB|Saint Martin (French Part)| +590
|MG|🇲🇬|U+1F1F2 U+1F1EC|Madagascar| +261
|MH|🇲🇭|U+1F1F2 U+1F1ED|Marshall Islands| +692
|MK|🇲🇰|U+1F1F2 U+1F1F0|Macedonia| +389
|ML|🇲🇱|U+1F1F2 U+1F1F1|Mali| +223
|MM|🇲🇲|U+1F1F2 U+1F1F2|Myanmar| +95
|MN|🇲🇳|U+1F1F2 U+1F1F3|Mongolia| +976
|MO|🇲🇴|U+1F1F2 U+1F1F4|Macao| +853
|MP|🇲🇵|U+1F1F2 U+1F1F5|Northern Mariana Islands| +1670
|MQ|🇲🇶|U+1F1F2 U+1F1F6|Martinique| +596
|MR|🇲🇷|U+1F1F2 U+1F1F7|Mauritania| +222
|MS|🇲🇸|U+1F1F2 U+1F1F8|Montserrat| +1664
|MT|🇲🇹|U+1F1F2 U+1F1F9|Malta| +356
|MU|🇲🇺|U+1F1F2 U+1F1FA|Mauritius| +230
|MV|🇲🇻|U+1F1F2 U+1F1FB|Maldives| +960
|MW|🇲🇼|U+1F1F2 U+1F1FC|Malawi| +265
|MX|🇲🇽|U+1F1F2 U+1F1FD|Mexico| +52
|MY|🇲🇾|U+1F1F2 U+1F1FE|Malaysia| +60
|MZ|🇲🇿|U+1F1F2 U+1F1FF|Mozambique| +258
|NA|🇳🇦|U+1F1F3 U+1F1E6|Namibia|+264
|NC|🇳🇨|U+1F1F3 U+1F1E8|New Caledonia| +687
|NE|🇳🇪|U+1F1F3 U+1F1EA|Niger| +227
|NF|🇳🇫|U+1F1F3 U+1F1EB|Norfolk Island| +672
|NG|🇳🇬|U+1F1F3 U+1F1EC|Nigeria|  +234
|NI|🇳🇮|U+1F1F3 U+1F1EE|Nicaragua| +505
|NL|🇳🇱|U+1F1F3 U+1F1F1|Netherlands| +31
|NO|🇳🇴|U+1F1F3 U+1F1F4|Norway| +47
|NP|🇳🇵|U+1F1F3 U+1F1F5|Nepal| +977
|NR|🇳🇷|U+1F1F3 U+1F1F7|Nauru| +674
|NU|🇳🇺|U+1F1F3 U+1F1FA|Niue| +683
|NZ|🇳🇿|U+1F1F3 U+1F1FF|New Zealand| +64
|OM|🇴🇲|U+1F1F4 U+1F1F2|Oman| +968
|PA|🇵🇦|U+1F1F5 U+1F1E6|Panama| +507
|PE|🇵🇪|U+1F1F5 U+1F1EA|Peru| +51
|PF|🇵🇫|U+1F1F5 U+1F1EB|French Polynesia| +689
|PG|🇵🇬|U+1F1F5 U+1F1EC|Papua New Guinea| +675
|PH|🇵🇭|U+1F1F5 U+1F1ED|Philippines| +63
|PK|🇵🇰|U+1F1F5 U+1F1F0|Pakistan| +92
|PL|🇵🇱|U+1F1F5 U+1F1F1|Poland| +48
|PM|🇵🇲|U+1F1F5 U+1F1F2|Saint Pierre and Miquelon| +508
|PN|🇵🇳|U+1F1F5 U+1F1F3|Pitcairn| +872
|PR|🇵🇷|U+1F1F5 U+1F1F7|Puerto Rico| +1939
|PS|🇵🇸|U+1F1F5 U+1F1F8|Palestinian Territory| +970
|PT|🇵🇹|U+1F1F5 U+1F1F9|Portugal| +351
|PW|🇵🇼|U+1F1F5 U+1F1FC|Palau| +680
|PY|🇵🇾|U+1F1F5 U+1F1FE|Paraguay| +595
|QA|🇶🇦|U+1F1F6 U+1F1E6|Qatar| +974
|RE|🇷🇪|U+1F1F7 U+1F1EA|Réunion| +262
|RO|🇷🇴|U+1F1F7 U+1F1F4|Romania| +40
|RS|🇷🇸|U+1F1F7 U+1F1F8|Serbia| +381
|RU|🇷🇺|U+1F1F7 U+1F1FA|Russia| +7
|RW|🇷🇼|U+1F1F7 U+1F1FC|Rwanda| +250
|SA|🇸🇦|U+1F1F8 U+1F1E6|Saudi Arabia| +966
|SB|🇸🇧|U+1F1F8 U+1F1E7|Solomon Islands| +677
|SC|🇸🇨|U+1F1F8 U+1F1E8|Seychelles| +248
|SD|🇸🇩|U+1F1F8 U+1F1E9|Sudan| +249
|SE|🇸🇪|U+1F1F8 U+1F1EA|Sweden| +46
|SG|🇸🇬|U+1F1F8 U+1F1EC|Singapore| +65
|SH|🇸🇭|U+1F1F8 U+1F1ED|Saint Helena, Ascension and Tristan Da Cunha| +290
|SI|🇸🇮|U+1F1F8 U+1F1EE|Slovenia| +386
|SJ|🇸🇯|U+1F1F8 U+1F1EF|Svalbard and Jan Mayen|
|SK|🇸🇰|U+1F1F8 U+1F1F0|Slovakia| +421
|SL|🇸🇱|U+1F1F8 U+1F1F1|Sierra Leone| +232
|SM|🇸🇲|U+1F1F8 U+1F1F2|San Marino| +378
|SN|🇸🇳|U+1F1F8 U+1F1F3|Senegal| +221
|SO|🇸🇴|U+1F1F8 U+1F1F4|Somalia| +252
|SR|🇸🇷|U+1F1F8 U+1F1F7|Suriname| +597
|SS|🇸🇸|U+1F1F8 U+1F1F8|South Sudan| +211
|ST|🇸🇹|U+1F1F8 U+1F1F9|Sao Tome and Principe| +239
|SV|🇸🇻|U+1F1F8 U+1F1FB|El Salvador| +503
|SX|🇸🇽|U+1F1F8 U+1F1FD|Sint Maarten (Dutch Part)| +1721
|SY|🇸🇾|U+1F1F8 U+1F1FE|Syrian Arab Republic| +963
|SZ|🇸🇿|U+1F1F8 U+1F1FF|Swaziland| +268
|TC|🇹🇨|U+1F1F9 U+1F1E8|Turks and Caicos Islands| +1649
|TD|🇹🇩|U+1F1F9 U+1F1E9|Chad| +235
|TF|🇹🇫|U+1F1F9 U+1F1EB|French Southern Territories| +262
|TG|🇹🇬|U+1F1F9 U+1F1EC|Togo| +228
|TH|🇹🇭|U+1F1F9 U+1F1ED|Thailand| +66
|TJ|🇹🇯|U+1F1F9 U+1F1EF|Tajikistan| +992
|TK|🇹🇰|U+1F1F9 U+1F1F0|Tokelau| +690
|TL|🇹🇱|U+1F1F9 U+1F1F1|Timor-Leste| +670
|TM|🇹🇲|U+1F1F9 U+1F1F2|Turkmenistan| +993
|TN|🇹🇳|U+1F1F9 U+1F1F3|Tunisia| +216
|TO|🇹🇴|U+1F1F9 U+1F1F4|Tonga| +676
|TR|🇹🇷|U+1F1F9 U+1F1F7|Turkey| +90
|TT|🇹🇹|U+1F1F9 U+1F1F9|Trinidad and Tobago| +1868
|TV|🇹🇻|U+1F1F9 U+1F1FB|Tuvalu| +688
|TW|🇹🇼|U+1F1F9 U+1F1FC|Taiwan| +886
|TZ|🇹🇿|U+1F1F9 U+1F1FF|Tanzania| +255
|UA|🇺🇦|U+1F1FA U+1F1E6|Ukraine| UA
|UG|🇺🇬|U+1F1FA U+1F1EC|Uganda| +256
|UM|🇺🇲|U+1F1FA U+1F1F2|United States Minor Outlying Islands| +1
|US|🇺🇸|U+1F1FA U+1F1F8|United States| +1
|UY|🇺🇾|U+1F1FA U+1F1FE|Uruguay| +598
|UZ|🇺🇿|U+1F1FA U+1F1FF|Uzbekistan| +998
|VA|🇻🇦|U+1F1FB U+1F1E6|Vatican City| +379
|VC|🇻🇨|U+1F1FB U+1F1E8|Saint Vincent and The Grenadines| +1784
|VE|🇻🇪|U+1F1FB U+1F1EA|Venezuela| +58
|VG|🇻🇬|U+1F1FB U+1F1EC|Virgin Islands, British| +1284
|VI|🇻🇮|U+1F1FB U+1F1EE|Virgin Islands, U.S.| +1340
|VN|🇻🇳|U+1F1FB U+1F1F3|Viet Nam| +84
|VU|🇻🇺|U+1F1FB U+1F1FA|Vanuatu| +678
|WF|🇼🇫|U+1F1FC U+1F1EB|Wallis and Futuna| +681
|WS|🇼🇸|U+1F1FC U+1F1F8|Samoa| +685
|YE|🇾🇪|U+1F1FE U+1F1EA|Yemen| +967
|YT|🇾🇹|U+1F1FE U+1F1F9|Mayotte| +262
|ZA|🇿🇦|U+1F1FF U+1F1E6|South Africa| +27
|ZM|🇿🇲|U+1F1FF U+1F1F2|Zambia| +260
|ZW|🇿🇼|U+1F1FF U+1F1FC|Zimbabwe| +263



## Contributing

Contributions are welcome! Please see our [Contributing Guide](CONTRIBUTING.md) for more details.Creating a `Code of Conduct` for your project involves defining the standards of behavior expected from contributors and maintainers. This document helps ensure that the community around your project is welcoming and collaborative. Here's a basic template you can use and customize for your project:


### Comming Soon
* Support for more ISO Standard Country Data
* Support for ISO 3166 Country A3 Codes
* Country ShortCode Enums



## License

This project is licensed under the terms of the [LICENSE](LICENSE).
