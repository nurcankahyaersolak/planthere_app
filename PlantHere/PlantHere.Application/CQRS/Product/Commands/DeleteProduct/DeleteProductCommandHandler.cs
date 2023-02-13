using MediatR;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Commands;
using ModelProduct = PlantHere.Domain.Aggregate.CategoryAggregate.Product;

namespace PlantHere.Application.CQRS.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, Unit>, ICommandRemoveCache
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.GetGenericRepository<ModelProduct>().GetByIdAsync(request.Id);

            await _unitOfWork.GetGenericRepository<ModelProduct>().RemoveAsync(product);

            return Unit.Value;
        }
    }
}
