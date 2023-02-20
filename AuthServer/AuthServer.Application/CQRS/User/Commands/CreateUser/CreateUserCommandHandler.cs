using AuthServer.Application.Exceptions;
using AuthServer.Application.Mapping;
using DotNetCore.CAP;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UdemyAuthServer.Core.UnitOfWork;
using ModelUser = AuthServer.Domain.Entities.User;

namespace AuthServer.Application.CQRS.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly ICapPublisher _capPublisher;

        private readonly IUnitOfWork _unitOfWork;

        private readonly UserManager<ModelUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateUserCommandHandler(ICapPublisher capPublisher, IUnitOfWork unitOfWork, UserManager<ModelUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _capPublisher = capPublisher;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {

            var user = new ModelUser
            {
                UserName = request.UserName,
                Email = request.Email
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                throw new ClientSideException(errors.FirstOrDefault());
            }
            else
            {
                var role = "customer";

                if (await _roleManager.FindByNameAsync(role) != null)
                {
                    await _userManager.AddToRoleAsync(user, role.ToLower());
                }
                else
                {
                    throw new NotFoundException($"Role({role}) not found");
                }
            }

            var userDto = ObjectMapper.Mapper.Map<CreateUserCommandResponse>(user);
            await _capPublisher.PublishAsync<string>("createUser.transaction", userDto.Id);
            await _unitOfWork.CommmitAsync();
            return userDto;
        }
    }
}
