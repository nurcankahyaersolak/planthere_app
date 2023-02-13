using AuthServer.Application.Exceptions;
using AuthServer.Application.Interfaces.Repositories;
using AuthServer.Application.Interfaces.Services;
using AuthServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UdemyAuthServer.Core.UnitOfWork;
using ModelUser = AuthServer.Domain.Entities.User;

namespace AuthServer.Application.CQRS.Authentication.Queries.CreateTokenByUser
{
    public class CreateTokenByUserCommandHandler : IRequestHandler<CreateTokenByUserCommand, CreateTokenByUserCommandResponse>
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly ITokenService _tokenService;

        private readonly UserManager<ModelUser> _userManager;

        public CreateTokenByUserCommandHandler(IUnitOfWork unitOfWork, ITokenService tokenService, UserManager<ModelUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<CreateTokenByUserCommandResponse> Handle(CreateTokenByUserCommand request, CancellationToken cancellationToken)
        {

            if (request == null) throw new ArgumentNullException(nameof(CreateTokenByUserCommand));

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null) throw new NotFoundException("Email or Password is wrong");

            if (!await _userManager.CheckPasswordAsync(user, request.Password)) throw new NotFoundException("Email or Password is wrong");

            var token = await _tokenService.CreateToken(user);

            var userRefreshToken = await _unitOfWork.GetGenericRepository<UserRefreshToken>().Where(x => x.UserId == user.Id).SingleOrDefaultAsync();

            if (userRefreshToken == null)
            {
                await _unitOfWork.GetGenericRepository<UserRefreshToken>().AddAsync(
                    new UserRefreshToken { UserId = user.Id, Code = token.RefreshToken, Expiration = token.RefreshTokenExpiration });
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.Expiration = token.RefreshTokenExpiration;
            }

            await _unitOfWork.CommmitAsync();
            return token;
        }
    }
}
