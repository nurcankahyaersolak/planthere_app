using AuthServer.API.CustomResponses;
using AuthServer.Application.CQRS.User.Commands.CreateUser;
using AuthServer.Application.CQRS.User.Commands.CreateUserRoles;
using AuthServer.Application.CQRS.User.Queries.GetUserByName;
using AuthServer.Application.Requests.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AuthServer.API.Controllers
{
    [Route("[controller]")]
    public class UserController : CustomBaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator; 
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
        /// Create User
        /// </summary>
        /// <param name="createUserRequest"></param>
        [HttpPost]
        public async Task<CustomResponse<CreateUserCommandResponse>> CreateUser(CreateUserRequest createUserRequest)
        {
            var command = new CreateUserCommand(createUserRequest.UserName,createUserRequest.Password,createUserRequest.Email);
            var result = await _mediator.Send(command);
            
            return CustomResponse<CreateUserCommandResponse>.Success(result, (int)HttpStatusCode.Created);
        }

        /// <summary>
        /// Create User Roles
        /// </summary>
        /// <param name="createUserRolesRequest"></param>
        [Authorize(Roles = "superadmin")]
        [HttpPost("[action]")]
        public async Task<CustomResponse<CreateUserRolesCommandResponse>> CreateUserRoles(CreateUserRolesRequest createUserRolesRequest)
        {
            var command = new CreateUserRolesCommand(createUserRolesRequest.Email, createUserRolesRequest.Roles);
            return CustomResponse<CreateUserRolesCommandResponse>.Success(await _mediator.Send(command), (int)HttpStatusCode.Created);
        }
    }
}