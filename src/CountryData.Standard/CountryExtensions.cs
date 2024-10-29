using System;
using System.Linq;

namespace CountryData.Standard
{
    /// <summary>
    /// Manages the CountryHelper instance and provides methods for retrieving country-related information.
    /// </summary>
    public class CountryExtensions : IDisposable
    {
        private CountryHelper _countryHelper;
        private bool _disposed = false;

        /// <summary>
        /// Constructor to initialize the CountryHelper instance.
        /// </summary>
        public CountryExtensions()
        {
            _countryHelper = new CountryHelper();
        }

        /// <summary>
        /// Gets the country code for the specified country name.
        /// </summary>
        /// <param name="countryName">The name of the country.</param>
        /// <returns>The country code if found; otherwise, null.</returns>
        public string GetCountryCode(string countryName)
        {
            if (countryName == null)
            {
                throw new ArgumentNullException(nameof(countryName));
            }

            var country = _countryHelper.GetCountryData()
                .FirstOrDefault(c => c.CountryName.Equals(countryName, StringComparison.OrdinalIgnoreCase));

            return country?.CountryShortCode;
        }

        /// <summary>
        /// Dispose method to clean up resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Protected method to dispose resources.
        /// </summary>
        /// <param name="disposing">Indicates whether the method is called from Dispose or finalizer.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing && _countryHelper != null)
                {
                    // Dispose managed resources.
                    _countryHelper = null;
                }

                // Dispose unmanaged resources.

                _disposed = true;
            }
        }

        /// <summary>
        /// Finalizer to ensure resources are cleaned up.
        /// </summary>
        ~CountryExtensions()
        {
            Dispose(false);
        }
    }
}
