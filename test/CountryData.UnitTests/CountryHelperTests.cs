using CountryData.Standard;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Tests the GetCurrencyCodesByCountryCode method in the CountryHelper class.
    /// This test verifies if the method correctly returns the primary currency (code and name) for a given country's short code.
    /// Assumes that each country has one primary currency for simplicity.
    /// </summary>
    /// <param name="shortCode">The short code of the country for which the currency information is to be retrieved.</param>
    /// <param name="expectedCode">The expected currency code associated with the given country's short code.</param>
    /// <param name="expectedName">The expected currency name associated with the given country's short code.</param>
    [Theory]
    [InlineData("AF", "AFN", "Afghan afghani")]
    [InlineData("GH", "GHS", "Ghanaian cedi")]
    public void GetCurrencyCodesByCountryCode_WithValidCountryCode_ShouldReturnCorrectCurrency(string shortCode,
        string expectedCode, string expectedName)
    {
        // Act
        var currencies = _countryHelper.GetCurrencyCodesByCountryCode(shortCode);

        // Assert
        var currency = currencies.FirstOrDefault();
        currency.Should().NotBeNull();
        currency.Code.Should().Be(expectedCode);
        currency.Name.Should().Be(expectedName);
    }



    /// <summary>
    /// Tests the GetCountryByCurrencyCode method in the CountryHelper class.
    /// This test verifies if the method correctly returns the countries associated with a given currency code.
    /// </summary>
    /// <param name="currencyCode">The currency code to search for.</param>
    /// <param name="expectedCountryShortCodes">The expected short codes of the countries associated with the currency code.</param>
    [Theory]
    [InlineData("AFN", new[] { "AF" })]
    [InlineData("USD", new[] { "US", "BQ", "IO", "EC", "SV", "GU", "MH", "FM", "MP", "PW", "PA", "PR", "TL", "TC", "UM", "VG", "ZW" })]
    public void GetCountryByCurrencyCode_WithValidCurrencyCode_ShouldReturnCorrectCountries(string currencyCode, string[] expectedCountryShortCodes)
    {
        // Act
        var countries = _countryHelper.GetCountryByCurrencyCode(currencyCode);

        // Assert
        var countryShortCodes = countries.Select(c => c.CountryShortCode).ToArray();
        countryShortCodes.Should().BeEquivalentTo(expectedCountryShortCodes);
    }

    /// <summary>
    /// Tests the GetCountryByCurrencyCode method in the CountryHelper class with an invalid currency code.
    /// This test checks if the method correctly returns an empty list when an invalid currency code is provided.
    /// </summary>
    [Fact]
    public void GetCountryByCurrencyCode_WithInvalidCurrencyCode_ShouldReturnEmptyList()
    {
        // Act
        var countries = _countryHelper.GetCountryByCurrencyCode("INVALID_CODE");

        // Assert
        countries.Should().BeEmpty();
    }

    /// <summary>
    /// Tests the GetCountryByCurrencyCode method in the CountryHelper class when the country data is not initialized.
    /// This test checks if the method throws an InvalidOperationException when the country data is not initialized.
    /// </summary>
    [Fact]
    public void GetCountryByCurrencyCode_WhenCountryDataIsNotInitialized_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var countryHelper = new CountryHelper();
        var field = typeof(CountryHelper).GetField("_Countries", BindingFlags.NonPublic | BindingFlags.Instance);
        field.SetValue(countryHelper, null);

        // Act
        Action act = () => countryHelper.GetCountryByCurrencyCode("USD");

        // Assert
        act.Should().Throw<InvalidOperationException>().WithMessage("Country data is not initialized.");
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
