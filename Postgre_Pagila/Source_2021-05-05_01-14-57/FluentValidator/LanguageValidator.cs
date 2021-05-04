using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class LanguageValidator : AbstractValidator<Language>
    {
        public LanguageValidator()
        {
            RuleFor(entity => entity.LanguageId).NotNull().WithMessage("LanguageId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.Name).NotNull().WithMessage("Name alan� bo� ge�ilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alan� bo� ge�ilemez.");
        }
    }
}