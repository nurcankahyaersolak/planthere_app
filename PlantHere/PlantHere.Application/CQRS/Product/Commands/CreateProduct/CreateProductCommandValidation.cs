using FluentValidation;
using PlantHere.Application.CQRS.Order.Commands.CreateOrder;

namespace PlantHere.Application.CQRS.Product.Commands.CreateProduct
{
    public class CreateOrderCommandValidation : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidation()
        {
            RuleFor(x => x.BuyerId).NotNull().WithMessage("{PropertyName} is required").NotEmpty().WithMessage("{PropertyName} is required");
        }

    }
}
