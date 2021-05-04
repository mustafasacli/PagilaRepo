using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(entity => entity.PaymentId).NotNull().WithMessage("PaymentId alaný boþ geçilemez.");

            RuleFor(entity => entity.CustomerId).NotNull().WithMessage("CustomerId alaný boþ geçilemez.");

            RuleFor(entity => entity.StaffId).NotNull().WithMessage("StaffId alaný boþ geçilemez.");

            RuleFor(entity => entity.RentalId).NotNull().WithMessage("RentalId alaný boþ geçilemez.");

            RuleFor(entity => entity.Amount).NotNull().WithMessage("Amount alaný boþ geçilemez.");

            RuleFor(entity => entity.PaymentDate).NotNull().WithMessage("PaymentDate alaný boþ geçilemez.");
        }
    }
}