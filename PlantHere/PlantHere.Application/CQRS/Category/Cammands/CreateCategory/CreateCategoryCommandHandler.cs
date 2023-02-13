using AutoMapper;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Commands;
using ModelCategory = PlantHere.Domain.Aggregate.CategoryAggregate.Category;

namespace PlantHere.Application.CQRS.Category.Cammands.CreateCategory
{
    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, CreateCategoryCommandResult>, ICommandRemoveCache
    {

        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateCategoryCommandResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.GetGenericRepository<ModelCategory>().AddAsync(_mapper.Map<ModelCategory>(request));
            return new CreateCategoryCommandResult();
        }
    }
}
