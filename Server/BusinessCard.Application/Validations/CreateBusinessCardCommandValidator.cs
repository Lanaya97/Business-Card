using BusinessCard.Application.Interfaces;
using FluentValidation;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Mail;
using System;
using BusinessCard.Application.Commands.BusinessCard.Create;

namespace BusinessCard.Application.Validations
{
    public sealed class CreateBusinessCardCommandValidator : AbstractValidator<CreateBusinessCardCommand>
    {
        private readonly IBusinessCardRepository _repository;

        public CreateBusinessCardCommandValidator(IBusinessCardRepository repository)
        {
            _repository = repository;

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 50).WithMessage("Name must be between 1 and 50 characters.")
                .MustAsync(BeUniqueName).WithMessage("Business card with the same name already exists");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .Must(IsValidEmail).WithMessage("Invalid email format")
                .MustAsync(BeUniqueEmail).WithMessage("Business card with the same email already exists");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Invalid phone number format.")
                .Length(8, 10).WithMessage("PhoneNumber Format is invalid")
                .MustAsync(BeUniquePhoneNumber).WithMessage("Business card with the same phone number already exists");
        }

        private async Task<bool> BeUniqueName(string name, CancellationToken cancellationToken)
        {
            return !await _repository.AnyAsync(x => x.Name == name);
        }

        private async Task<bool> BeUniqueEmail(string email, CancellationToken cancellationToken)
        {
            return !await _repository.AnyAsync(x => x.Email == email);
        }

        private async Task<bool> BeUniquePhoneNumber(string phoneNumber, CancellationToken cancellationToken)
        {
            return !await _repository.AnyAsync(x => x.PhoneNumber.Number == phoneNumber);
        }

        public static bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
