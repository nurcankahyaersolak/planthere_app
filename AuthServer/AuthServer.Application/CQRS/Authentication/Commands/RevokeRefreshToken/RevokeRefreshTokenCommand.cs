using MediatR;

namespace AuthServer.Application.CQRS.Authentication.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommand : IRequest<RevokeRefreshTokenCommandResponse>
    {
        public string RefleshToken { get; set; }


        public RevokeRefreshTokenCommand(string refleshToken)
        {
            RefleshToken = refleshToken;
        }
    }
}
