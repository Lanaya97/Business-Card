using BusinessCard.Application.Common;
using BusinessCard.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCard.Application.Commands.BusinessCard.Create
{
    public sealed class CreateBusinessCardCommand : IRequest<Result<Guid>>
    {
        public string Name { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string CountryCode { get; set; }

        public string Phone { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public string Photo { get; set; } = string.Empty;
    }
}
