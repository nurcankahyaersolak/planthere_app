﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantHere.Application.CQRS.Order.Commands.CreateOrder;
using PlantHere.Application.CQRS.Order.Commands.UpdateOrder;
using PlantHere.Application.CQRS.Order.Quries.GetOrderById;
using PlantHere.Application.CQRS.Order.Quries.GetOrderByUserId;
using PlantHere.Application.CQRS.Product.Commands.DeleteProduct;
using PlantHere.WebAPI.CustomResults;
using System.Net;
using System.Security.Claims;

namespace PlantHere.WebAPI.Controllers
{

    public class OrderController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Get Order By Id 
        /// </summary>
        /// <param name="id"></param>
        [Authorize(Roles = "superadmin")]
        [HttpGet("{id}")]
        public async Task<CustomResult<GetOrderByIdQueryResult>> GetOrderById(int id)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery(id));
            return CustomResult<GetOrderByIdQueryResult>.Success((int)HttpStatusCode.OK, order);
        }

        /// <summary>
        /// Get Order By User Id
        /// </summary>
        [Authorize(Roles = "customer,superadmin")]
        [HttpGet("[action]")]
        public async Task<CustomResult<ICollection<GetOrderByUserIdQueryResult>>> GetOrderByUserId()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            return CustomResult<ICollection<GetOrderByUserIdQueryResult>>.Success((int)HttpStatusCode.OK, await _mediator.Send(new GetOrderByUserIdQuery(userId)));
        }

        /// <summary>
        /// Update Order
        /// </summary>
        /// <param name="command"></param>
        [Authorize(Roles = "superadmin")]
        [HttpPut]
        public async Task<CustomResult<GetOrderByIdQueryResult>> UpdateOrder(UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return CustomResult<GetOrderByIdQueryResult>.Success((int)HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Create Order
        /// </summary>
        /// <param name="command"></param>
        [Authorize(Roles = "superadmin")]
        [HttpPost]
        public async Task<CustomResult<CreateOrderCommandResult>> CreateOrder(CreateOrderCommand command)
        {
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
