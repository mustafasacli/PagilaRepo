using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(entity => entity.CustomerId).NotNull().WithMessage("CustomerId alaný boþ geçilemez.");

            RuleFor(entity => entity.StoreId).NotNull().WithMessage("StoreId alaný boþ geçilemez.");

            RuleFor(entity => entity.FirstName).NotEmpty().WithMessage("FirstName alaný boþ geçilemez.");

            RuleFor(entity => entity.LastName).NotEmpty().WithMessage("LastName alaný boþ geçilemez.");

            RuleFor(entity => entity.AddressId).NotNull().WithMessage("AddressId alaný boþ geçilemez.");

            RuleFor(entity => entity.Activebool).NotNull().WithMessage("Activebool alaný boþ geçilemez.");

            RuleFor(entity => entity.CreateDate).NotNull().WithMessage("CreateDate alaný boþ geçilemez.");
        }
    }
}