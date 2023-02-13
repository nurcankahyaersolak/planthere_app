using FluentValidation;
using PlantHere.Application.CQRS.BasketItem.Commands.CreateBasketItem;

namespace PlantHere.Application.CQRS.BasketItem.Commands.DeleteBasketItem
{
    public class DeleteBasketItemCommandValidation : AbstractValidator<CreateBasketItemCommand>
    {
        public DeleteBasketItemCommandValidation()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.ProductId).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        }
    }
}
