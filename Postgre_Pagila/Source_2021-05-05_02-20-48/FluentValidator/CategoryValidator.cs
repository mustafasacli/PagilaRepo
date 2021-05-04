using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(entity => entity.CategoryId).NotNull().WithMessage("CategoryId alaný boþ geçilemez.");

            RuleFor(entity => entity.Name).NotEmpty().WithMessage("Name alaný boþ geçilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alaný boþ geçilemez.");
        }
    }
}