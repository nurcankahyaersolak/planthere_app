using FluentValidation;

namespace PlantHere.Application.CQRS.Basket.Commands.CreateBasket
{
    public class CreateBasketCommandValidation : AbstractValidator<CreateBasketCommand>
    {
        public CreateBasketCommandValidation()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
