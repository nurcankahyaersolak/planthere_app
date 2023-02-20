using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlantHere.Application.Exceptions;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Queries;
using ModelProduct = PlantHere.Domain.Aggregate.CategoryAggregate.Product;

namespace PlantHere.Application.CQRS.Product.Queries.GetProductByUniqueId
{
    public class GetProductByUniqueIdQueryHandler : IQueryHandler<GetProductByUniqueIdQuery, GetProductByUniqueIdQueryResult>, IQueryCacheable
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;
        public TimeSpan Expiration => TimeSpan.FromSeconds(20);

        public GetProductByUniqueIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetProductByUniqueIdQueryResult> Handle(GetProductByUniqueIdQuery request, CancellationToken cancellationToken)
        {
            var products = _unitOfWork.GetGenericRepository<ModelProduct>().GetQueryableAsNoTracking();
            var product = await products.Include(x => x.Images).FirstOrDefaultAsync(x => x.UniqueId == request.UniqueId);
            if (product == null) throw new NotFoundException($"Not Found Product({request.UniqueId})");
            return _mapper.Map<GetProductByUniqueIdQueryResult>(product);
        }
    }
}
