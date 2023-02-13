using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Commands;
using ModelAddress = PlantHere.Domain.Aggregate.OrderAggregate.ValueObjects.Address;
using ModelOrder = PlantHere.Domain.Aggregate.OrderAggregate.Entities.Order;
using ModelOrderItem = PlantHere.Domain.Aggregate.OrderAggregate.Entities.OrderItem;

namespace PlantHere.Application.CQRS.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : ICommandHandler<UpdateOrderCommand, UpdateOrderCommandResult>, ICommandRemoveCache
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public UpdateOrderCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateOrderCommandResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.GetGenericRepository<ModelOrder>().Where(x => x.Id == request.Id).Include(x => x.Address).Include(x => x.OrderItems).FirstOrDefaultAsync();
            order.UpdateOrder(request.BuyerId, _mapper.Map<ModelAddress>(request.Address), _mapper.Map<List<ModelOrderItem>>(request.OrderItems));
            return new UpdateOrderCommandResult();
        }
    }
}
