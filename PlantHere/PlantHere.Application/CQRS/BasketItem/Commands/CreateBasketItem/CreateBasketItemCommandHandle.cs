using Microsoft.EntityFrameworkCore;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Commands;
using ModelBasket = PlantHere.Domain.Aggregate.BasketAggregate.Entities.Basket;

namespace PlantHere.Application.CQRS.BasketItem.Commands.CreateBasketItem
{
    public class CreateBasketItemCommandHandle : ICommandHandler<CreateBasketItemCommand, CreateBasketItemCommandResult>, ICommandRemoveCache
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBasketItemCommandHandle(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateBasketItemCommandResult> Handle(CreateBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basketRepository = _unitOfWork.GetGenericRepository<ModelBasket>();

            var basket = await basketRepository.Where(x => x.UserId == request.UserId).Include(x => x.BasketItems).FirstOrDefaultAsync();

            if (basket == null)
            {
                await basketRepository.AddAsync(new ModelBasket(request.UserId));
                await _unitOfWork.CommitAsync();
                basket = await basketRepository.Where(x => x.UserId == request.UserId).Include(x => x.BasketItems).FirstOrDefaultAsync();
            }

            basket.AddBasketItem(request.ProductId, request.ProductName, request.Price, request.DiscountedPrice);

            return new CreateBasketItemCommandResult();
        }
    }
}
