using FluentValidation;

namespace PlantHere.Application.CQRS.Basket.Commands.BuyBasket
{
    public class BuyBasketCommandValidation : AbstractValidator<BuyBasketCommand>
    {
        public BuyBasketCommandValidation()
        {
            RuleFor(x => x.Address).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Payment).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
