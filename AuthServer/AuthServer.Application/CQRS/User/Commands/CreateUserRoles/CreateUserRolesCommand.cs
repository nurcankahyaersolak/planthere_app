using MediatR;

namespace AuthServer.Application.CQRS.User.Commands.CreateUserRoles
{
    public class CreateUserRolesCommand : IRequest<CreateUserRolesCommandResponse>
    {
        public string Email { get; set; }

        public List<string> Roles { get; set; }

        public CreateUserRolesCommand(string email, List<string> roles)
        {
            Email = email;
            Roles = roles;
        }
    }
}
