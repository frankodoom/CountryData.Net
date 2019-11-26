# CountryData.Standard
:earth_africa: A simple cross platform offline .NET library for getting Global Country Data


### Initialize the Country data object

```cSharp
       //loads all Country Data in the constructor (You can initialize this once as a singleton)
       var helper = new CountryHelper();
```


### Get list of Countries 
```cSharp
       var countries = helper.GetCountries();
       foreach (var item in countries)
       {
        Console.WriteLine(item);
       }
```


### Get list of Regions in a Country by Country Code
```cSharp
       var regions = helper.GetRegionByCountryCode("GH");
       foreach (var region in regions)
       {
        Console.WriteLine(item.Name);
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
        Console.WriteLine(item);
       }
       
       
       //example 2
       data.Where(x => x.CountryShortCode == "US")
                              .Select(r=>r.Regions).FirstOrDefault()
                              .ToList();
```





```
The MIT License

Copyright (c) 2019 Frank Odoom

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
