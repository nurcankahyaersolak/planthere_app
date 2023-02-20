using AuthServer.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using UdemyAuthServer.Core.UnitOfWork;
using ModelUser = AuthServer.Domain.Entities.User;

namespace AuthServer.Application.CQRS.User.Commands.CreateUserRoles
{
    public class CreateUserRolesCommandHandler : IRequestHandler<CreateUserRolesCommand, CreateUserRolesCommandResponse>
    {
        private readonly UserManager<ModelUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IUnitOfWork _unitOfWork;

        public CreateUserRolesCommandHandler(UserManager<ModelUser> userManager, RoleManager<IdentityRole> roleManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        public async Task<CreateUserRolesCommandResponse> Handle(CreateUserRolesCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null) throw new NotFoundException("User Not Found");

            if (request.Roles == null) throw new NotFoundException("Roles Not Found");

            foreach (var role in request.Roles.Select(x => x.ToLower()))
            {
                if (await _roleManager.FindByNameAsync(role) != null)
                {
                    await _userManager.AddToRoleAsync(user, role.ToLower());
                }
                else
                {
                    throw new NotFoundException($"Role({role}) not found");
                }
            }

            await _unitOfWork.CommmitAsync();
            return new CreateUserRolesCommandResponse();
        }
    }
}
