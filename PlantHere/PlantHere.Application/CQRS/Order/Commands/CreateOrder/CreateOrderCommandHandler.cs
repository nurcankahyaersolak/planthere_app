using AutoMapper;
using DotNetCore.CAP;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Commands;
using ModelOrder = PlantHere.Domain.Aggregate.OrderAggregate.Entities.Order;
using ModelOrderItem = PlantHere.Domain.Aggregate.OrderAggregate.Entities.OrderItem;


namespace PlantHere.Application.CQRS.Order.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, CreateOrderCommandResult>, ICommandRemoveCache
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly ICapPublisher _capPublisher;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ICapPublisher capPublisher)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _capPublisher = capPublisher;
        }

        public async Task<CreateOrderCommandResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            var order = _mapper.Map<ModelOrder>(request);
            order = order.AddOrder(_mapper.Map<List<ModelOrderItem>>(request.OrderItems));

            await _unitOfWork.GetGenericRepository<ModelOrder>().AddAsync(order);

            await _capPublisher.PublishAsync<int>("createOrder.transaction", order.Id);

            return new CreateOrderCommandResult();
        }
    }
}