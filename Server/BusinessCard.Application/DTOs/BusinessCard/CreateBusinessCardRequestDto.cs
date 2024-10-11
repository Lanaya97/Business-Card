using BusinessCard.Domain.Enums;
using System;
using System.Text.Json.Serialization;

namespace BusinessCard.Application.DTOs.BusinessCard
{
    public sealed class CreateBusinessCardRequestDto
    {
        public string Name { get;  set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]

        public Gender Gender { get;  set; }

        public DateTime DateOfBirth { get;  set; }

        public string Email { get;  set; }

        public string CountryCode { get; set; }

        public string Number { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string? Photo { get;  set; } = string.Empty;
    }
}
