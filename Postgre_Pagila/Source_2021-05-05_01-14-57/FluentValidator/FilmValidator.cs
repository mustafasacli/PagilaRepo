using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class FilmValidator : AbstractValidator<Film>
    {
        public FilmValidator()
        {
            RuleFor(entity => entity.FilmId).NotNull().WithMessage("FilmId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.Title).NotEmpty().WithMessage("Title alan� bo� ge�ilemez.");

            RuleFor(entity => entity.LanguageId).NotNull().WithMessage("LanguageId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.RentalDuration).NotNull().WithMessage("RentalDuration alan� bo� ge�ilemez.");

            RuleFor(entity => entity.RentalRate).NotNull().WithMessage("RentalRate alan� bo� ge�ilemez.");

            RuleFor(entity => entity.ReplacementCost).NotNull().WithMessage("ReplacementCost alan� bo� ge�ilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alan� bo� ge�ilemez.");

            RuleFor(entity => entity.Fulltext).NotNull().WithMessage("Fulltext alan� bo� ge�ilemez.");
        }
    }
}