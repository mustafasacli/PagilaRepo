using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class FilmValidator : AbstractValidator<Film>
    {
        public FilmValidator()
        {
            RuleFor(entity => entity.FilmId).NotNull().WithMessage("FilmId alaný boþ geçilemez.");

            RuleFor(entity => entity.Title).NotEmpty().WithMessage("Title alaný boþ geçilemez.");

            RuleFor(entity => entity.LanguageId).NotNull().WithMessage("LanguageId alaný boþ geçilemez.");

            RuleFor(entity => entity.RentalDuration).NotNull().WithMessage("RentalDuration alaný boþ geçilemez.");

            RuleFor(entity => entity.RentalRate).NotNull().WithMessage("RentalRate alaný boþ geçilemez.");

            RuleFor(entity => entity.ReplacementCost).NotNull().WithMessage("ReplacementCost alaný boþ geçilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alaný boþ geçilemez.");

            RuleFor(entity => entity.Fulltext).NotNull().WithMessage("Fulltext alaný boþ geçilemez.");
        }
    }
}