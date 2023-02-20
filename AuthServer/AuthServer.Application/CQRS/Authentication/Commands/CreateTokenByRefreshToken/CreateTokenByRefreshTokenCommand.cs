using MediatR;

namespace AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByRefreshToken
{
    public class CreateTokenByRefreshTokenCommand : IRequest<CreateTokenByRefreshTokenCommandResponse>
    {
        public string RefreshToken { get; set; }

        public CreateTokenByRefreshTokenCommand(string refreshToken)
        {
            RefreshToken = refreshToken;
        }
    }
}
