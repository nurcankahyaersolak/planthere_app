using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlantHere.Application.Exceptions;
using PlantHere.Application.Interfaces;
using PlantHere.Application.Interfaces.Commands;
using ModelBasket = PlantHere.Domain.Aggregate.BasketAggregate.Entities.Basket;

namespace PlantHere.Application.CQRS.Basket.Commands.CreateBasket
{
    public class CreateBasketCommandHandle : ICommandHandler<CreateBasketCommand, CreateBasketCommandResult>, ICommandRemoveCache
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBasketCommandHandle(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateBasketCommandResult> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
        {
            var basket = await _unitOfWork.GetGenericRepository<ModelBasket>().Where(x => x.UserId == request.UserId).FirstOrDefaultAsync();

            if (basket != null) throw new ConflictException($"{typeof(ModelBasket).Name}({request.UserId}) Conflict");

            await _unitOfWork.GetGenericRepository<ModelBasket>().AddAsync(_mapper.Map<ModelBasket>(request));

            return new CreateBasketCommandResult();
        }
    }
}
