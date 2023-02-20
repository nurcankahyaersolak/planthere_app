using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantHere.Application.CQRS.BasketItem.Commands.CreateBasketItem;
using PlantHere.Application.CQRS.BasketItem.Commands.DeleteBasketItem;
using PlantHere.Application.CQRS.BasketItem.Commands.UpdateBasketItem;
using PlantHere.Application.Requests.BasketItems;
using PlantHere.WebAPI.CustomResults;
using System.Net;
using System.Security.Claims;

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
        /// <param name="createBasketItemRequest"></param>
        [Authorize(Roles = "superadmin,customer")]
        [HttpPost]
        public async Task<CustomResult<CreateBasketItemCommand>> CreateBasketItem(CreateBasketItemRequest createBasketItemRequest)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value; ;
            var command = new CreateBasketItemCommand(createBasketItemRequest.ProductId, userId, createBasketItemRequest.ProductName, createBasketItemRequest.Price, createBasketItemRequest.DiscountedPrice);
            await _mediator.Send(command);

            return CustomResult<CreateBasketItemCommand>.Success(204);
        }

        /// <summary>
        /// Delete Basket Item
        /// </summary>
        /// <param name="deleteBasketItemRequest"></param>
        [Authorize(Roles = "superadmin,customer")]
        [HttpDelete]
        public async Task<CustomResult<DeleteBasketItemCommandResult>> DeleteBasketItem(DeleteBasketItemRequest deleteBasketItemRequest)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var command = new DeleteBasketItemCommand(userId, deleteBasketItemRequest.ProductId);

            return CustomResult<DeleteBasketItemCommandResult>.Success((int)HttpStatusCode.OK, await _mediator.Send(command));
        }

        /// <summary>
        /// Update Basket Item
        /// </summary>
        /// <param name="updateBasketItemRequest"></param>
        [Authorize(Roles = "superadmin,customer")]
        [HttpPut]
        public async Task<CustomResult<UpdateBasketItemCommandResult>> UpdateBasketItem(UpdateBasketItemRequest updateBasketItemRequest)
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var command = new UpdateBasketItemCommand(updateBasketItemRequest.ProductId, userId, updateBasketItemRequest.Count);

            return CustomResult<UpdateBasketItemCommandResult>.Success((int)HttpStatusCode.OK, await _mediator.Send(command));
        }
    }
}
