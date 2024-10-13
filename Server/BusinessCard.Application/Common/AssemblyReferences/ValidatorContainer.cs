using FluentValidation;
using System;

namespace BusinessCard.Application.Common.AssemblyReferences
{
    // Used as a reference to add all validators to the container.
    public sealed class ValidatorContainer : AbstractValidator<Type>
    {
    }
}
