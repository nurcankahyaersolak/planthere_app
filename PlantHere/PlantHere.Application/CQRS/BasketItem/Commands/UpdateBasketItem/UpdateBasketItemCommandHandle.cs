using Microsoft.EntityFrameworkCore;
using PlantHere.Application.Exceptions;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Commands;
using ModelBasket = PlantHere.Domain.Aggregate.BasketAggregate.Entities.Basket;
using ModelBasketItem = PlantHere.Domain.Aggregate.BasketAggregate.Entities.BasketItem;

namespace PlantHere.Application.CQRS.BasketItem.Commands.UpdateBasketItem
{
    public class UpdateBasketItemCommandHandle : ICommandHandler<UpdateBasketItemCommand, UpdateBasketItemCommandResult>, ICommandRemoveCache
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBasketItemCommandHandle(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateBasketItemCommandResult> Handle(UpdateBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basket = await _unitOfWork.GetGenericRepository<ModelBasket>().Where(x => x.UserId == request.UserId).Include(x => x.BasketItems).FirstOrDefaultAsync();
            if (basket == null) throw new NotFoundException($"{typeof(ModelBasket).Name}({request.UserId}) Not Found");

            var basketItem = basket.BasketItems.FirstOrDefault(x => x.ProductId == request.ProductId);
            if (basketItem == null) throw new NotFoundException($"{typeof(ModelBasketItem).Name}({request.ProductId}) Not Found");

            basket.UpdateBasketItem(basketItem, request.Count);

            return new UpdateBasketItemCommandResult();
        }

    }
}
