using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Commands;
using ModelCategory = PlantHere.Domain.Aggregate.CategoryAggregate.Category;

namespace PlantHere.Application.CQRS.Category.Cammands.DeleteCategory
{
    public class DeleteCategoryCommadHandler : ICommandHandler<DeleteCategoryCommand, DeleteCategoryCommandResult>, ICommandRemoveCache
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommadHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteCategoryCommandResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.GetGenericRepository<ModelCategory>().GetByIdAsync(request.Id);

            var category = await _unitOfWork.GetGenericRepository<ModelCategory>().GetByIdAsync(request.Id);

            await _unitOfWork.GetGenericRepository<ModelCategory>().RemoveAsync(category);

            return new DeleteCategoryCommandResult();
        }
    }
}
