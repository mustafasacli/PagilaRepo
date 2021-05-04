using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class FilmCategoryValidator : AbstractValidator<FilmCategory>
    {
        public FilmCategoryValidator()
        {
            RuleFor(entity => entity.FilmId).NotNull().WithMessage("FilmId alaný boþ geçilemez.");

            RuleFor(entity => entity.CategoryId).NotNull().WithMessage("CategoryId alaný boþ geçilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alaný boþ geçilemez.");
        }
    }
}