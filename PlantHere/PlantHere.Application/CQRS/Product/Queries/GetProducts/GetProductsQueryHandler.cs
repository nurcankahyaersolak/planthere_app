using AutoMapper;
using MediatR;
using PlantHere.Application.CQRS.Product.Queries.GetAllProducts;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Queries;
using ModelProduct = PlantHere.Domain.Aggregate.CategoryAggregate.Product;


namespace PlantHere.Application.CQRS.Product.Queries.GetAll
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<GetProductsQueryResult>>, IQueryCacheable
    {
        public TimeSpan Expiration => TimeSpan.FromSeconds(20);

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GetProductsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetProductsQueryResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.GetGenericRepository<ModelProduct>().GetAsync();
            return _mapper.Map<IEnumerable<GetProductsQueryResult>>(products);
        }
    }
}
