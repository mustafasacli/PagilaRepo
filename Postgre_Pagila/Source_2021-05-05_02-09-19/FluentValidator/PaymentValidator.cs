using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(entity => entity.PaymentId).NotNull().WithMessage("PaymentId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.CustomerId).NotNull().WithMessage("CustomerId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.StaffId).NotNull().WithMessage("StaffId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.RentalId).NotNull().WithMessage("RentalId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.Amount).NotNull().WithMessage("Amount alan� bo� ge�ilemez.");

            RuleFor(entity => entity.PaymentDate).NotNull().WithMessage("PaymentDate alan� bo� ge�ilemez.");
        }
    }
}