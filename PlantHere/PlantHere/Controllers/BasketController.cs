﻿using DotNetCore.CAP;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlantHere.Application.CQRS.Basket.Commands.BuyBasket;
using PlantHere.Application.CQRS.Basket.Commands.CreateBasket;
using PlantHere.Application.CQRS.Basket.Queries.GetBasketByUserId;
using PlantHere.WebAPI.CustomResults;
using System.Net;
using System.Security.Claims;


namespace PlantHere.WebAPI.Controllers
{
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
            return CustomResult<CreateBasketCommandResult>.Success((int)HttpStatusCode.OK, await _mediator.Send(new CreateBasketCommand(userId)));
        }

        /// <summary>
        /// Buy Basket
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "customer,superadmin")]
        [HttpPost("[Action]")]
        public async Task<CustomResult<BuyBasketCommandResult>> BuyBasket(BuyBasketCommand command)
        {
            command.UserId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            await _mediator.Send(command);
            return CustomResult<BuyBasketCommandResult>.Success(200);
        }
    }
}