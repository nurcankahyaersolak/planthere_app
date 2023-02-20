using MediatR;

namespace AuthServer.Application.CQRS.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<CreateUserCommandResponse>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public CreateUserCommand(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
        }
    }
}
