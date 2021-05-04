using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class FilmActorValidator : AbstractValidator<FilmActor>
    {
        public FilmActorValidator()
        {
            RuleFor(entity => entity.ActorId).NotNull().WithMessage("ActorId alaný boþ geçilemez.");

            RuleFor(entity => entity.FilmId).NotNull().WithMessage("FilmId alaný boþ geçilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alaný boþ geçilemez.");
        }
    }
}