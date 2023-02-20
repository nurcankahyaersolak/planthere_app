using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantHere.Application.CQRS.Order.Commands.CreateOrder;
using PlantHere.Application.CQRS.Order.Quries.GetOrderById;
using PlantHere.Application.CQRS.Order.Quries.GetOrderByUserId;
using PlantHere.Application.CQRS.Product.Commands.DeleteProduct;
using PlantHere.Application.Requests.Orders;
using PlantHere.WebAPI.CustomResults;
using System.Net;
using System.Security.Claims;

namespace PlantHere.WebAPI.Controllers
{
    [Route("orders")]
    public class OrderController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Get Order By User Id
        /// </summary>
        [Authorize(Roles = "customer,superadmin")]
        [HttpGet]
        public async Task<CustomResult<ICollection<GetOrderByUserIdQueryResult>>> GetOrderByUserId()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return CustomResult<ICollection<GetOrderByUserIdQueryResult>>.Success((int)HttpStatusCode.OK, await _mediator.Send(new GetOrderByUserIdQuery(userId)));
        }

        /// <summary>
        /// Update Order
        /// </summary>
        /// <param name="updateOrderRequest"></param>
        [Authorize(Roles = "superadmin")]
        [HttpPut]
        public async Task<CustomResult<GetOrderByIdQueryResult>> UpdateOrder(UpdateOrderRequest updateOrderRequest)
        {
            var command = new UpdateOrderRequest(updateOrderRequest.Id, updateOrderRequest.CreatedDate, updateOrderRequest.Address, updateOrderRequest.BuyerId, updateOrderRequest.OrderItems);
            await _mediator.Send(command);
            return CustomResult<GetOrderByIdQueryResult>.Success((int)HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Create Order
        /// </summary>
        /// <param name="createOrderRequest"></param>
        [Authorize(Roles = "superadmin")]
        [HttpPost]
        public async Task<CustomResult<CreateOrderCommandResult>> CreateOrder(CreateOrderRequest createOrderRequest)
        {
            var command = new CreateOrderCommand(createOrderRequest.CreatedDate, createOrderRequest.Address, createOrderRequest.BuyerId, createOrderRequest.OrderItems);
            return CustomResult<CreateOrderCommandResult>.Success((int)HttpStatusCode.Created, await _mediator.Send(command));
        }

        /// <summary>
        /// Delete Order
        /// </summary>
        /// <param name="id"></param>
        [Authorize(Roles = "superadmin")]
        [HttpDelete("{id}")]
        public async Task<CustomResult<DeleteProductCommand>> DeleteOrder(int id)
        {
            await _mediator.Send(new DeleteProductCommand(id));
            return CustomResult<DeleteProductCommand>.Success((int)HttpStatusCode.NoContent);
        }

    }
}
