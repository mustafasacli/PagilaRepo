using System;
using FluentValidation;

namespace Pagila.Entity
{
    public class InventoryValidator : AbstractValidator<Inventory>
    {
        public InventoryValidator()
        {
            RuleFor(entity => entity.InventoryId).NotNull().WithMessage("InventoryId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.FilmId).NotNull().WithMessage("FilmId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.StoreId).NotNull().WithMessage("StoreId alan� bo� ge�ilemez.");

            RuleFor(entity => entity.LastUpdate).NotNull().WithMessage("LastUpdate alan� bo� ge�ilemez.");
        }
    }
}