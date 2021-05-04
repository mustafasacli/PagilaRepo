using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class LanguageValidator : AbstractValidator<Language>
    {
        public LanguageValidator()
        {
            RuleFor(entity => entity.LanguageId).NotNull().WithMessage("LanguageId alaný boþ geçilemez.");

            RuleFor(entity => entity.Name).NotNull().WithMessage("Name alaný boþ geçilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alaný boþ geçilemez.");
        }
    }
}