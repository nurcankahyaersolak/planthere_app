using MediatR;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Commands;
using ModelCategory = PlantHere.Domain.Aggregate.CategoryAggregate.Category;
using ModelProduct = PlantHere.Domain.Aggregate.CategoryAggregate.Product;


namespace PlantHere.Application.CQRS.Product.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : ICommandHandler<UpdateProductCommand, Unit>, ICommandRemoveCache
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.GetGenericRepository<ModelCategory>().GetByIdAsync(request.CategoryId);

            var product = await _unitOfWork.GetGenericRepository<ModelProduct>().GetByIdAsync(request.Id);

            product.Name = request.Name;
            product.Stock = request.Stock;
            product.Price = request.Price;
            product.UpdatedDate = DateTime.Now;
            product.Description = request.Description;

            await _unitOfWork.GetGenericRepository<ModelProduct>().UpdateAsync(product);

            return Unit.Value;
        }
    }
}
