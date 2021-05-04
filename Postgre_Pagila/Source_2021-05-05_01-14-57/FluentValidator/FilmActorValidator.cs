using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class FilmActorValidator : AbstractValidator<FilmActor>
    {
        public FilmActorValidator()
        {
            RuleFor(entity => entity.ActorId).NotNull().WithMessage("ActorId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.FilmId).NotNull().WithMessage("FilmId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alan� bo� ge�ilemez.");
        }
    }
}