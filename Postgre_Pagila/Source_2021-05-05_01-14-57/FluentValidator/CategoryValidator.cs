using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(entity => entity.CategoryId).NotNull().WithMessage("CategoryId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.Name).NotEmpty().WithMessage("Name alan� bo� ge�ilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alan� bo� ge�ilemez.");
        }
    }
}