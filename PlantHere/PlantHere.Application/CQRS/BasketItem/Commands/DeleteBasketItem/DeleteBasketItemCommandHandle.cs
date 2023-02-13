using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PlantHere.Application.Exceptions;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Commands;
using ModelBasket = PlantHere.Domain.Aggregate.BasketAggregate.Entities.Basket;
using ModelBasketItem = PlantHere.Domain.Aggregate.BasketAggregate.Entities.BasketItem;

namespace PlantHere.Application.CQRS.BasketItem.Commands.DeleteBasketItem
{
    public class DeleteBasketItemCommandHandle : ICommandHandler<DeleteBasketItemCommand, DeleteBasketItemCommandResult>, ICommandRemoveCache
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBasketItemCommandHandle(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteBasketItemCommandResult> Handle(DeleteBasketItemCommand request, CancellationToken cancellationToken)
        {
            var basket = await _unitOfWork.GetGenericRepository<ModelBasket>().Where(x => x.UserId == request.UserId).Include(x => x.BasketItems).FirstOrDefaultAsync();
            if (basket == null) throw new NotFoundException($"{typeof(ModelBasket).Name}({request.UserId}) Not Found");

            var basketItems = basket.BasketItems.Where(x => x.ProductId == request.ProductId).ToList();
            if (basketItems == null) throw new NotFoundException($"{typeof(ModelBasketItem).Name}({request.ProductId}) Not Found");

            basket.DeleteBasketItem(basketItems);

            return new DeleteBasketItemCommandResult();
        }

    }
}
