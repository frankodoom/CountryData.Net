using CountryData.Standard;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace CountryData.UnitTests;

public class CountryHelperTests
{
    //Arrange
    private readonly CountryHelper _countryHelper  = new();

    [Fact]
    public void GetCountryData_ShouldReturnListOfCountryData()
    {
        //Act
        var countryData = _countryHelper.GetCountryData();

        //Assert
        countryData.Should().BeAssignableTo<IEnumerable<Country>>();
        countryData.Should().NotBeNullOrEmpty();
    }

    [Theory]
    [InlineData("GH")]
    [InlineData("US")]
    public void GetCountryByCode_WithCorrectCode_ShouldReturnCountry(string shortCode) 
    {
        //Act
        var country = _countryHelper.GetCountryByCode(shortCode);

        //Assert
        country.Should().NotBeNull();
        country.CountryShortCode.Should().Be(shortCode);
    }
}
