using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(entity => entity.CustomerId).NotNull().WithMessage("CustomerId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.StoreId).NotNull().WithMessage("StoreId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.FirstName).NotEmpty().WithMessage("FirstName alan� bo� ge�ilemez.");

            RuleFor(entity => entity.LastName).NotEmpty().WithMessage("LastName alan� bo� ge�ilemez.");

            RuleFor(entity => entity.AddressId).NotNull().WithMessage("AddressId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.Activebool).NotNull().WithMessage("Activebool alan� bo� ge�ilemez.");

            RuleFor(entity => entity.CreateDate).NotNull().WithMessage("CreateDate alan� bo� ge�ilemez.");
        }
    }
}