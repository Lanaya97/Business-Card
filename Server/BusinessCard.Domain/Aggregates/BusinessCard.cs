using BusinessCard.Domain.Enums;
using BusinessCard.Domain.ValueObjects;
using System;


namespace BusinessCard.Domain
{
    public class BusinessCard : AggregateRoot<Guid>
    {
        public string Name { get; private set; }

        public Gender Gender { get; private set; }

        public DateTime DateOfBirth { get; private set; }

        public string Email { get; private set; }

        public PhoneNumber PhoneNumber { get; private set; }

        public Address Address { get; private set; }

        public string? Photo { get; private set; } = string.Empty;

        private BusinessCard(string name, Gender gender, DateTime dateOfBirth, string email, PhoneNumber phoneNumber, Address address, string? photo = null)
        {
            Name = name;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            Photo = photo;
        }

        public static BusinessCard Create(
        string name,
        Gender gender,
        DateTime dateOfBirth,
        string email,
        string countryCode,
        string phoneNumber,
        string street,
        string city,
        string zipCode,
        string? photo = null)
        {

            var phone = new PhoneNumber(countryCode, phoneNumber);
            var address = new Address(street, city, zipCode);

            return new BusinessCard(name, gender, dateOfBirth, email, phone, address, photo);
        }

        public BusinessCard Update(string? name = null,
                                   Gender? gender = null,
                                   DateTime? dateOfBirth = null,
                                   string? email = null,
                                   PhoneNumber? phoneNumber = null,
                                   Address? address = null,
                                   string? photo = null)
        {
            if(!string.IsNullOrWhiteSpace(name) && name != Name) 
            {
                Name = name;
            }
            if(gender != null && gender != Gender)
            {
                Gender = gender.Value;
            }
            if(dateOfBirth != null && dateOfBirth != DateOfBirth)
            {
                DateOfBirth = dateOfBirth.Value;
            }
            if(!string.IsNullOrWhiteSpace(email) && email != Email)
            {
                Email = email;
            }
            if(phoneNumber != null && phoneNumber != PhoneNumber)
            {
                PhoneNumber = phoneNumber;
            }
            if(address != null && address != Address)
            {
                Address = address;
            }
            if(!string.IsNullOrWhiteSpace(photo) && photo != Photo)
            {
                Photo = photo;
            }

            return this;
        }
        
    }
}
