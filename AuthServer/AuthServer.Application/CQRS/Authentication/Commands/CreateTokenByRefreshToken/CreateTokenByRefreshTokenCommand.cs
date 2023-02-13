using MediatR;

namespace AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByRefreshToken
{
    public class CreateTokenByRefreshTokenCommand : IRequest<CreateTokenByRefreshTokenCommandResponse>
    {
        public string RefreshToken { get; set; }

    }
}
