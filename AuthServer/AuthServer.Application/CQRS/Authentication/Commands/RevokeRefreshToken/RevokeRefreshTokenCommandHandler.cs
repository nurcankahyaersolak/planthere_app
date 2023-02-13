using AuthServer.Application.Exceptions;
using AuthServer.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UdemyAuthServer.Core.UnitOfWork;

namespace AuthServer.Application.CQRS.Authentication.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommandHandler : IRequestHandler<RevokeRefreshTokenCommand, RevokeRefreshTokenCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RevokeRefreshTokenCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RevokeRefreshTokenCommandResponse> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var existRefreshToken = await _unitOfWork.GetGenericRepository<UserRefreshToken>().Where(x => x.Code == request.RefleshToken).SingleOrDefaultAsync();
            if (existRefreshToken == null) throw new NotFoundException("Refresh token not found");

            _unitOfWork.GetGenericRepository<UserRefreshToken>().Remove(existRefreshToken);
            return new RevokeRefreshTokenCommandResponse();

        }
    }
}
