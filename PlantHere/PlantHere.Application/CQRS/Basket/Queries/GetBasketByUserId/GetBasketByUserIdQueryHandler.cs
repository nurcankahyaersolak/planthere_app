using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Queries;
using ModelBasket = PlantHere.Domain.Aggregate.BasketAggregate.Entities.Basket;

namespace PlantHere.Application.CQRS.Basket.Queries.GetBasketByUserId
{
    public class GetBasketByUserIdQueryHandler : IRequestHandler<GetBasketByUserIdQuery, GetBasketByUserIdQueryResult>, IQueryCacheable
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetBasketByUserIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public TimeSpan Expiration => TimeSpan.FromSeconds(20);

        public async Task<GetBasketByUserIdQueryResult> Handle(GetBasketByUserIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<GetBasketByUserIdQueryResult>(await _unitOfWork.GetGenericRepository<ModelBasket>().Where(x => x.UserId == request.UserId).Include(x => x.BasketItems).FirstOrDefaultAsync());
        }
    }
}
