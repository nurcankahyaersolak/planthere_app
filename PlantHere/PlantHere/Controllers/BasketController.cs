using DotNetCore.CAP;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantHere.Application.CQRS.Basket.Commands.BuyBasket;
using PlantHere.Application.CQRS.Basket.Commands.CreateBasket;
using PlantHere.Application.CQRS.Basket.Queries.GetBasketByUserId;
using PlantHere.Application.Requests.Basket;
using PlantHere.WebAPI.CustomResults;
using System.Net;
using System.Security.Claims;

namespace PlantHere.WebAPI.Controllers
{
    [Route("baskets")]
    public class BasketController : CustomBaseController
    {
        private readonly IMediator _mediator;


        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get Basket By User Id
        /// </summary>
        [Authorize(Roles = "customer,superadmin")]
        [HttpGet]
        public async Task<CustomResult<GetBasketByUserIdQueryResult>> GetBasketByUserId()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return CustomResult<GetBasketByUserIdQueryResult>.Success((int)HttpStatusCode.OK, await _mediator.Send(new GetBasketByUserIdQuery(userId)));
        }

        /// <summary>
        /// Create Basket
        /// </summary>
        [CapSubscribe("buyBasket.transaction")]
        [CapSubscribe("createUser.transaction")]
        [HttpPost]
        public async Task<CustomResult<CreateBasketCommandResult>> CreateBasket(string userId)
        {
            var command = new CreateBasketCommand(userId);
            return CustomResult<CreateBasketCommandResult>.Success((int)HttpStatusCode.OK, await _mediator.Send(command));
        }

        /// <summary>
        /// Buy Basket
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "customer,superadmin")]
        [HttpPost("buy")]
        public async Task<CustomResult<BuyBasketCommandResult>> BuyBasket(BuyBasketRequest buyBasketRequest)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var command = new BuyBasketCommand(userId, buyBasketRequest.Address, buyBasketRequest.Payment);

            await _mediator.Send(command);

            return CustomResult<BuyBasketCommandResult>.Success(200);
        }
    }
}
