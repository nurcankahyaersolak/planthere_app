using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Commands;
using ModelCategory = PlantHere.Domain.Aggregate.CategoryAggregate.Category;

namespace PlantHere.Application.CQRS.Category.Cammands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, UpdateCategoryCommandResult>, ICommandRemoveCache
    {

        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UpdateCategoryCommandResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.GetGenericRepository<ModelCategory>().GetByIdAsync(request.Id);

            var category = await _unitOfWork.GetGenericRepository<ModelCategory>().GetByIdAsync(request.Id);

            category.NameEn = request.NameEn;
            category.NameTr = request.NameTr;

            await _unitOfWork.GetGenericRepository<ModelCategory>().UpdateAsync(category);

            return new UpdateCategoryCommandResult();
        }
    }
}
