using System;
using System.Collections.Generic;
using BusinessCard.Domain.Abstractions;

namespace BusinessCard.Domain.ValueObjects
{
    public sealed class PhoneNumber : ValueObject
    {
        public string CountryCode { get; }
        public string Number { get; }

        public PhoneNumber(string countryCode, string number)
        {
            if (string.IsNullOrWhiteSpace(countryCode) || !IsValidCountryCode(countryCode))
            {
                throw new ArgumentException("Invalid phone number format.");
            }
            CountryCode = countryCode;

            if (string.IsNullOrWhiteSpace(number) || !IsValidPhoneNumber(number))
            {
                throw new ArgumentException("Invalid phone number format.");
            }
            Number = number;
        }

        private bool IsValidCountryCode(string countryCode)
        {
            // Add logic to validate phone number format
            return true; // Simplified for the example
        }

        private bool IsValidPhoneNumber(string number)
        {
            // Add logic to validate phone number format
            return true; // Simplified for the example
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
        }
    }

}
