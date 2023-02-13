using MediatR;
using Microsoft.EntityFrameworkCore;
using PlantHere.Application.Exceptions;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Commands;
using ModelOrder = PlantHere.Domain.Aggregate.OrderAggregate.Entities.Order;

namespace PlantHere.Application.CQRS.Order.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : ICommandHandler<DeleteOrderCommand, Unit>, ICommandRemoveCache
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.GetGenericRepository<ModelOrder>().Where(x => x.Id == request.Id).FirstOrDefaultAsync();

            if (order == null) throw new NotFoundException($"{typeof(ModelBuilder).Name}({request.Id}) Not Found");

            await _unitOfWork.GetGenericRepository<ModelOrder>().RemoveAsync(order);

            return Unit.Value;
        }
    }
}
