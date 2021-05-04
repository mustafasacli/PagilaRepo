using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class ActorValidator : AbstractValidator<Actor>
    {
        public ActorValidator()
        {
            RuleFor(entity => entity.ActorId).NotNull().WithMessage("ActorId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.FirstName).NotEmpty().WithMessage("FirstName alan� bo� ge�ilemez.");

            RuleFor(entity => entity.LastName).NotEmpty().WithMessage("LastName alan� bo� ge�ilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alan� bo� ge�ilemez.");
        }
    }
}