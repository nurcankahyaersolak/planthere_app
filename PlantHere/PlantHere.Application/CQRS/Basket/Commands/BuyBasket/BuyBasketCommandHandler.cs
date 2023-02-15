using AutoMapper;
using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;
using PlantHere.Application.Exceptions;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Commands;
using PlantHere.Application.Interfaces.Services;
using ModelBasket = PlantHere.Domain.Aggregate.BasketAggregate.Entities.Basket;
using ModelOrder = PlantHere.Domain.Aggregate.OrderAggregate.Entities.Order;
using ModelOrderItem = PlantHere.Domain.Aggregate.OrderAggregate.Entities.OrderItem;

namespace PlantHere.Application.CQRS.Basket.Commands.BuyBasket
{
    public class BuyBasketCommandHandler : ICommandHandler<BuyBasketCommand, BuyBasketCommandResult>, ICommandRemoveCache
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ICapPublisher _capPublisher;

        private readonly IPaymentService _paymentService;

        private readonly IMapper _mapper;

        public BuyBasketCommandHandler(IUnitOfWork unitOfWork, ICapPublisher capPublisher, IPaymentService paymentService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _capPublisher = capPublisher;
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<BuyBasketCommandResult> Handle(BuyBasketCommand request, CancellationToken cancellationToken)
        {

            if (_paymentService.ReceiverPayment(request.Payment.CardTypeId, request.Payment.CardNumber, request.Payment.CardSecurityNumber, request.Payment.CardHolderName))
            {
                // Get Basket Repository
                var basketRepository = _unitOfWork.GetGenericRepository<ModelBasket>();

                // Get Basket By User Id
                var basket = await basketRepository.Where(x => x.UserId == request.UserId).Include(x => x.BasketItems).FirstOrDefaultAsync();

                if (basket == null) throw new NotFoundException($"{typeof(ModelBasket).Name}({request.UserId}) Not Found");

                // Basket Items Count Cheak
                if (basket.BasketItems.Count == 0) throw new NotFoundException($"Not Found Basket Items");

                // Create Order
                var orderRepository = _unitOfWork.GetGenericRepository<ModelOrder>();

                var orderItems = _mapper.Map<List<ModelOrderItem>>(basket.BasketItems);

                await orderRepository.AddAsync(new ModelOrder(request.UserId, request.Address, orderItems));
   
                // Remove Basket
                basketRepository.Remove(basket);

                // Rabbit MQ Publish
                await _capPublisher.PublishAsync<string>("buyBasket.transaction", request.UserId);
            }

            return new BuyBasketCommandResult();
        }
    }
}
