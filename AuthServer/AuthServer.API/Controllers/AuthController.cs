using AuthServer.Application.CQRS.Authentication.Commands.RevokeRefreshToken;
using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByRefreshToken;
using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByUser;
using AuthServer.API.CustomResponses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AuthServer.API.Controllers
{
    [Route("[controller]/[action]")]
    public class AuthController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Create Token By User
        /// </summary>
        /// <param name="createTokenByUserQuery"></param>
        [HttpPost]
        public async Task<CustomResponse<CreateTokenByUserCommandResponse>> CreateTokenByUser(CreateTokenByUserCommand createTokenByUserQuery)
        {
            var result = await _mediator.Send(createTokenByUserQuery);

            return CustomResponse<CreateTokenByUserCommandResponse>.Success(result, (int)HttpStatusCode.Created);
        }

        /// <summary>
        /// Revoke Refresh Token
        /// </summary>
        /// <param name="revokeRefreshTokenCommand"></param>
        [HttpPost]
        public async Task<CustomResponse<RevokeRefreshTokenCommandResponse>> RevokeRefreshToken(RevokeRefreshTokenCommand revokeRefreshTokenCommand)
        {
            var result = await _mediator.Send(revokeRefreshTokenCommand);

            return CustomResponse<RevokeRefreshTokenCommandResponse>.Success(result, (int)HttpStatusCode.OK);
        }

        /// <summary>
        /// Create Token By Refresh Token
        /// </summary>
        /// <param name="createTokenByRefreshTokenCommand"></param>
        [HttpPost]
        public async Task<CustomResponse<CreateTokenByRefreshTokenCommandResponse>> CreateTokenByRefreshToken(CreateTokenByRefreshTokenCommand createTokenByRefreshTokenCommand)
        {
            var result = await _mediator.Send(createTokenByRefreshTokenCommand);

            return CustomResponse<CreateTokenByRefreshTokenCommandResponse>.Success(result, (int)HttpStatusCode.Created);
        }
    }
}