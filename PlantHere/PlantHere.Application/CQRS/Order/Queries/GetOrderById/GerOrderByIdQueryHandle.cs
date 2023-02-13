using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Queries;
using ModelOrder = PlantHere.Domain.Aggregate.OrderAggregate.Entities.Order;

namespace PlantHere.Application.CQRS.Order.Quries.GetOrderById
{
    public class GerOrderByIdQueryHandle : IQueryHandler<GetOrderByIdQuery, GetOrderByIdQueryResult>, IQueryCacheable
    {
        private readonly IMapper _mapper;

        private readonly IUnitOfWork _unitOfWork;
        public TimeSpan Expiration => TimeSpan.FromSeconds(20);

        public GerOrderByIdQueryHandle(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetOrderByIdQueryResult> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var orders = await _unitOfWork.GetGenericRepository<ModelOrder>().Where(x => x.Id == request.Id).Include(x => x.Address).Include(x => x.OrderItems).FirstOrDefaultAsync();

            return _mapper.Map<GetOrderByIdQueryResult>(orders);
        }
    }

}
