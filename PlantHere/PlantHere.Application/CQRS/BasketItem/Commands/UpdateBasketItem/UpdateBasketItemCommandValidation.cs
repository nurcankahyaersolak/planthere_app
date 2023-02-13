using FluentValidation;

namespace PlantHere.Application.CQRS.BasketItem.Commands.UpdateBasketItem
{
    public class UpdateBasketItemCommandValidation : AbstractValidator<UpdateBasketItemCommand>
    {
        public UpdateBasketItemCommandValidation()
        {
            RuleFor(x => x.Count).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
