using CountryData.Standard;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CountryData.UnitTests;

public class CountryHelperTests
{
    //Arrange
    private readonly CountryHelper _countryHelper = new();

    [Fact]
    public void GetCountryData_ShouldReturnListOfCountryData()
    {
        //Act
        var countryData = _countryHelper.GetCountryData();

        //Assert
        countryData.Should().BeAssignableTo<IEnumerable<Country>>();
        countryData.Should().NotBeNullOrEmpty();
    }


    /// <summary>
    ///  tesing 
    /// </summary>
    /// <param name="shortCode"></param>

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


    /// <summary>
    ///  Tests the GetCountryFlagByCode method in the CountryHelper class.
    ///  This test verifies if the method correctly returns the emoji flag associated with a given country's short code.
    /// </summary>
    /// <param name="shortCode">The short code of the country for which the emoji flag is to be retrieved.</param>

    [Theory]
    [InlineData("GH")]
    [InlineData("CM")]
    [InlineData("US")]
    public void GetCountryFlagByCode_WithCorrectCode_ShouldReturnEmojiFlag(string shortCode)
    {
        //Act
        var countryFlag = _countryHelper.GetCountryEmojiFlag(shortCode);

        //Assert
        countryFlag.Should().NotBeNull();
        if (shortCode == "GH")
            countryFlag.Should().Be("🇬🇭");
        else if (shortCode == "CM")
            countryFlag.Should().Be("🇨🇲");
        else if (shortCode == "US")
            countryFlag.Should().Be("🇺🇸");
    }

    /// <summary>
    ///  Tests the GetCountryByCode method in the CountryHelper class with incorrect short codes.
    ///  This test checks if the method correctly returns null when an incorrect short code is provided.
    /// </summary>
    /// <param name="shortCode">The incorrect short code of the country to be retrieved.</param>

    [Theory]
    [InlineData("GHA")]
    [InlineData("G")]
    [InlineData("USB")]
    public void GetCountryByCode_WithInCorrectCode_ShouldReturnNull(string shortCode)
    {
        //Act
        var country = _countryHelper.GetCountryByCode(shortCode);

        //Assert
        country.Should().BeNull();
    }


    /// <summary>
    ///  Tests the GetPhoneCodeByCountryShortCode method in the CountryHelper class.
    ///  This test verifies if the method correctly returns the phone code associated with a given country's short code.
    /// </summary>
    /// <param name="shortCode">The short code of the country for which the phone code is to be retrieved.</param>
    /// <param name="expectedPhoneCode">The expected phone code of the country associated with the given short code.</param>

    [Theory]
    [InlineData("GH", "+233")]
    [InlineData("US", "+1")]
    public void GetPhoneCodeByCountryShortCode_WithCorrectShortCode_ShouldReturnPhoneCode(string shortCode, string expectedPhoneCode)
    {
        //Act
        var phoneCode = _countryHelper.GetPhoneCodeByCountryShortCode(shortCode);

        //Assert
        phoneCode.Should().NotBeNull();
        phoneCode.Should().Be(expectedPhoneCode);
    }


    /// <summary>
    ///  Tests the GetCountryByPhoneCode method in the CountryHelper class.
    ///  This test checks if the method correctly returns the country associated with a given phone code.
    /// </summary>
    /// <param name="phoneCode">The phone code of the country to be retrieved.</param>
    /// <param name="expectedShortCode">The expected short code of the country associated with the phone code.</param>

    [Theory]
    [InlineData("+233", "GH")]
    [InlineData("+1", "US")]
    public void GetCountriesByPhoneCode_WithCorrectPhoneCode_ShouldReturnCountries(string phoneCode, string expectedShortCode)
    {
        //Act
        var countries = _countryHelper.GetCountryByPhoneCode(phoneCode);

        //Assert
        countries.Should().NotBeNullOrEmpty();
        countries.Any(c => c.CountryShortCode == expectedShortCode).Should().BeTrue();
    }


    /// <summary>
    ///  Tests the GetRegionByCountryCode method in the CountryHelper class.
    ///  This test verifies if the method correctly returns the regions associated with a given country's short code.
    /// </summary>
    /// <param name="shortCode">The short code of the country for which the regions are to be retrieved.</param>

    [Theory]
    [InlineData("LK")]
    public void GetRegions_WithCorrectCode_ShouldReturnCountryRegions(string shortCode)
    {
        //Act
        var regions = _countryHelper.GetRegionByCountryCode(shortCode);

        //Assert
        regions.Should().NotBeNull();
        if (shortCode == "LK")
        {
            regions.Should().HaveCount(9);
        }
    }
}
