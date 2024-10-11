using BusinessCard.Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCard.Application.Commands.BusinessCard.Delete
{
    public sealed class DeleteBusinessCardCommand : IRequest<Result<bool>>
    {
        public Guid Id { get; set; }
    }
}
