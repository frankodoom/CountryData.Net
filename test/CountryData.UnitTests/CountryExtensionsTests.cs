using CountryData.Standard;
using FluentAssertions;
using System;
using Xunit;

namespace CountryData.UnitTests
{
    public class CountryHelperManagerTests
    {
        /// <summary>
        /// Tests that GetCountryCode returns the correct country code for a valid country name.
        /// </summary>
        [Fact]
        public void GetCountryCode_ValidCountryName_ReturnsCountryCode()
        {
            // Arrange
            using var manager = new CountryExtensions();
            var countryName = "United States";

            // Act
            var result = manager.GetCountryCode(countryName);

            // Assert
            result.Should().Be("US");
        }

        /// <summary>
        /// Tests that GetCountryCode returns null for an invalid country name.
        /// </summary>
        [Fact]
        public void GetCountryCode_InvalidCountryName_ReturnsNull()
        {
            // Arrange
            using var manager = new CountryExtensions();
            var countryName = "Invalid Country";

            // Act
            var result = manager.GetCountryCode(countryName);

            // Assert
            result.Should().BeNull();
        }

        /// <summary>
        /// Tests that GetCountryCode throws an ArgumentNullException for a null country name.
        /// </summary>
        [Fact]
        public void GetCountryCode_NullCountryName_ThrowsArgumentNullException()
        {
            // Arrange
            using var manager = new CountryExtensions();
            string? countryName = null;

            // Act
            Action act = () => manager.GetCountryCode(countryName!);

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        /// <summary>
        /// Tests that Dispose method sets the _disposed flag to true.
        /// </summary>
        [Fact]
        public void Dispose_SetsDisposedFlagToTrue()
        {
            // Arrange
            var manager = new CountryExtensions();

            // Act
            manager.Dispose();

            // Assert
            var disposedField = typeof(CountryExtensions).GetField("_disposed", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var disposedValue = (bool)disposedField.GetValue(manager);
            disposedValue.Should().BeTrue();
        }

        /// <summary>
        /// Tests that Dispose method sets the _countryHelper to null.
        /// </summary>
        [Fact]
        public void Dispose_SetsCountryHelperToNull()
        {
            // Arrange
            var manager = new CountryExtensions();

            // Act
            manager.Dispose();

            // Assert
            var countryHelperField = typeof(CountryExtensions).GetField("_countryHelper", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var countryHelperValue = countryHelperField.GetValue(manager);
            countryHelperValue.Should().BeNull();
        }
    }
}
