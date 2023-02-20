using AuthServer.API.CustomResponses;
using AuthServer.Application.CQRS.Authentication.Commands.RevokeRefreshToken;
using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByRefreshToken;
using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByUser;
using AuthServer.Application.Requests.Authentications;
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
        /// <param name="createTokenByUserRequest"></param>
        [HttpPost]
        public async Task<CustomResponse<CreateTokenByUserCommandResponse>> CreateTokenByUser(CreateTokenByUserRequest createTokenByUserRequest)
        {
            var command = new CreateTokenByUserCommand(createTokenByUserRequest.Email, createTokenByUserRequest.Password);

            var result = await _mediator.Send(command);

            return CustomResponse<CreateTokenByUserCommandResponse>.Success(result, (int)HttpStatusCode.Created);
        }

        /// <summary>
        /// Revoke Refresh Token
        /// </summary>
        /// <param name="revokeRefreshTokenRequest"></param>
        [HttpPost]
        public async Task<CustomResponse<RevokeRefreshTokenCommandResponse>> RevokeRefreshToken(RevokeRefreshTokenRequest revokeRefreshTokenRequest)
        {
            var command = new RevokeRefreshTokenCommand(revokeRefreshTokenRequest.RefleshToken);

            var result = await _mediator.Send(command);

            return CustomResponse<RevokeRefreshTokenCommandResponse>.Success(result, (int)HttpStatusCode.OK);
        }

        /// <summary>
        /// Create Token By Refresh Token
        /// </summary>
        /// <param name="createTokenByRefreshTokenRequest"></param>
        [HttpPost]
        public async Task<CustomResponse<CreateTokenByRefreshTokenCommandResponse>> CreateTokenByRefreshToken(CreateTokenByRefreshTokenRequest createTokenByRefreshTokenRequest)
        {
            var command = new CreateTokenByRefreshTokenCommand(createTokenByRefreshTokenRequest.RefreshToken);

            var result = await _mediator.Send(command);

            return CustomResponse<CreateTokenByRefreshTokenCommandResponse>.Success(result, (int)HttpStatusCode.Created);
        }
    }
}