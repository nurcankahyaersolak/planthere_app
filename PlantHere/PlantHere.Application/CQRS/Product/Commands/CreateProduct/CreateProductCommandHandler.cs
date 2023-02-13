using AutoMapper;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Commands;
using ModelCategory = PlantHere.Domain.Aggregate.CategoryAggregate.Category;
using ModelProduct = PlantHere.Domain.Aggregate.CategoryAggregate.Product;

namespace PlantHere.Application.CQRS.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductCommandResult>, ICommandRemoveCache
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateProductCommandResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.GetGenericRepository<ModelCategory>().GetByIdAsync(request.CategoryId);

            await _unitOfWork.GetGenericRepository<ModelProduct>().AddAsync(_mapper.Map<ModelProduct>(request));

            return new CreateProductCommandResult();
        }
    }
}
