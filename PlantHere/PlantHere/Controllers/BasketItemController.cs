using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Net;
using MediatR;
using PlantHere.WebAPI.CustomResults;
using PlantHere.Application.CQRS.BasketItem.Commands.CreateBasketItem;
using PlantHere.Application.CQRS.BasketItem.Commands.DeleteBasketItem;
using PlantHere.Application.CQRS.BasketItem.Commands.UpdateBasketItem;

namespace PlantHere.WebAPI.Controllers
{
    [Route("basket-items")]
    public class BasketItemController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public BasketItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create Basket Item
        /// </summary>
        /// <param name="command"></param>
        [Authorize(Roles = "superadmin,customer")]
        [HttpPost]
        public async Task<CustomResult<CreateBasketItemCommand>> CreateBasketItem(CreateBasketItemCommand command)
        {
            command.UserId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value; ;
            await _mediator.Send(command);
            return CustomResult<CreateBasketItemCommand>.Success(204);
        }

        /// <summary>
        /// Delete Basket Item
        /// </summary>
        /// <param name="command"></param>
        [Authorize(Roles = "superadmin,customer")]
        [HttpDelete]
        public async Task<CustomResult<DeleteBasketItemCommandResult>> DeleteBasketItem(DeleteBasketItemCommand command)
        {
            command.UserId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value; ;
            return CustomResult<DeleteBasketItemCommandResult>.Success((int)HttpStatusCode.OK, await _mediator.Send(command));
        }

        /// <summary>
        /// Update Basket Item
        /// </summary>
        /// <param name="command"></param>
        [Authorize(Roles = "superadmin,customer")]
        [HttpPut]
        public async Task<CustomResult<UpdateBasketItemCommandResult>> UpdateBasketItem(UpdateBasketItemCommand command)
        {
            command.UserId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return CustomResult<UpdateBasketItemCommandResult>.Success((int)HttpStatusCode.OK, await _mediator.Send(command));
        }
    }
}
