using FluentValidation;
using PlantHere.Application.CQRS.BasketItem.Commands.CreateBasketItem;

namespace PlantHere.Application.CQRS.Product.Commands.CreateProduct
{
    public class CreateBasketItemCommandValidation : AbstractValidator<CreateBasketItemCommand>
    {
        public CreateBasketItemCommandValidation()
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.ProductId).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.Price).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
            RuleFor(x => x.ProductName).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        }

    }
}
