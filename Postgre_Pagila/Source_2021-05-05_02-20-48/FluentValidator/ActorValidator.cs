using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class ActorValidator : AbstractValidator<Actor>
    {
        public ActorValidator()
        {
            RuleFor(entity => entity.ActorId).NotNull().WithMessage("ActorId alaný boþ geçilemez.");

            RuleFor(entity => entity.FirstName).NotEmpty().WithMessage("FirstName alaný boþ geçilemez.");

            RuleFor(entity => entity.LastName).NotEmpty().WithMessage("LastName alaný boþ geçilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alaný boþ geçilemez.");
        }
    }
}