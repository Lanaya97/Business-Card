using BusinessCard.Application.ReadModels.BusinessCard.Shared;
using BusinessCard.Domain.Enums;
using System;

namespace BusinessCard.Application.ReadModels.BusinessCard
{
    public class BusinessCardReadModel
    {
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public PhoneNumberReadModel PhoneNumber { get; set; }

        public AddressReadModel Address { get; set; }

        public string? Photo { get; set; } = string.Empty;
    }

}
