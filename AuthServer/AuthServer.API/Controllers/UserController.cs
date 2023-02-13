using AuthServer.Application.CQRS.User.Commands.CreateUser;
using AuthServer.Application.CQRS.User.Commands.CreateUserRoles;
using AuthServer.Application.CQRS.User.Queries.GetUserByName;
using AuthServer.API.CustomResponses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AuthServer.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="createUserCommand"></param>
        [HttpPost]
        public async Task<CustomResponse<CreateUserCommandResponse>> CreateUser(CreateUserCommand createUserCommand)
        {
            var result = await _mediator.Send(createUserCommand);
            return CustomResponse<CreateUserCommandResponse>.Success(result, (int)HttpStatusCode.Created);
        }

        /// <summary>
        /// Get User
        /// </summary>
        [Authorize]
        [HttpGet]
        public async Task<CustomResponse<GetUserByNameQueryResponse>> GetUser()
        {
            var user = await _mediator.Send(new GetUserByNameQuery(HttpContext.User.Identity.Name));
            return CustomResponse<GetUserByNameQueryResponse>.Success(user, (int)HttpStatusCode.OK);
        }

        /// <summary>
        /// Create User Roles
        /// </summary>
        /// <param name="createUserRolesCommand"></param>
        [Authorize(Roles = "superadmin")]
        [HttpPost("[action]")]
        public async Task<CustomResponse<CreateUserRolesCommandResponse>> CreateUserRoles(CreateUserRolesCommand createUserRolesCommand)
        {
            return CustomResponse<CreateUserRolesCommandResponse>.Success(await _mediator.Send(createUserRolesCommand), (int)HttpStatusCode.Created);
        }
    }
}