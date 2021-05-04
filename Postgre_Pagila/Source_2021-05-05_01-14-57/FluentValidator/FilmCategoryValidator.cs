using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class FilmCategoryValidator : AbstractValidator<FilmCategory>
    {
        public FilmCategoryValidator()
        {
            RuleFor(entity => entity.FilmId).NotNull().WithMessage("FilmId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.CategoryId).NotNull().WithMessage("CategoryId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alan� bo� ge�ilemez.");
        }
    }
}