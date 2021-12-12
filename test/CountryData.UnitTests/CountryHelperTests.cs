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

}
