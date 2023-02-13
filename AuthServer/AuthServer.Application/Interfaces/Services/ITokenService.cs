using AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByUser;
using AuthServer.Domain.Entities;


namespace AuthServer.Application.Interfaces.Services
{
    public interface ITokenService
    {
        Task<CreateTokenByUserCommandResponse> CreateToken(User user);
    }
}