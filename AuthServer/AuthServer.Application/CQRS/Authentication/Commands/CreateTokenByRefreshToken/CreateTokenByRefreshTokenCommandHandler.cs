using AuthServer.Application.Exceptions;
using AuthServer.Application.Interfaces.Repositories;
using AuthServer.Application.Interfaces.Services;
using AuthServer.Application.Mapping;
using AuthServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UdemyAuthServer.Core.UnitOfWork;
using ModelUser = AuthServer.Domain.Entities.User;

namespace AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByRefreshToken
{
    public class CreateTokenByRefreshTokenCommandHandler : IRequestHandler<CreateTokenByRefreshTokenCommand, CreateTokenByRefreshTokenCommandResponse>
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly ITokenService _tokenService;

        private readonly UserManager<ModelUser> _userManager;

        public CreateTokenByRefreshTokenCommandHandler(IUnitOfWork unitOfWork, ITokenService tokenService, UserManager<ModelUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<CreateTokenByRefreshTokenCommandResponse> Handle(CreateTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var existRefreshToken = await _unitOfWork.GetGenericRepository<UserRefreshToken>().Where(x => x.Code == request.RefreshToken).SingleOrDefaultAsync();
            if (existRefreshToken == null) throw new NotFoundException("Refresh token not found");

            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);
            if (user == null) throw new NotFoundException("User Id not found");

            var token = await _tokenService.CreateToken(user);

            existRefreshToken.Code = token.RefreshToken;
            existRefreshToken.Expiration = token.RefreshTokenExpiration;

            await _unitOfWork.CommmitAsync();

            return ObjectMapper.Mapper.Map<CreateTokenByRefreshTokenCommandResponse>(token);

        }
    }
}
