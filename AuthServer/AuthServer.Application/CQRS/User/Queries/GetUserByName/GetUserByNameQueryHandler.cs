using AuthServer.Application.Exceptions;
using AuthServer.Application.Mapping;
using MediatR;
using Microsoft.AspNetCore.Identity;
using ModelUser = AuthServer.Domain.Entities.User;

namespace AuthServer.Application.CQRS.User.Queries.GetUserByName
{
    public class GetUserByNameQueryHandler : IRequestHandler<GetUserByNameQuery, GetUserByNameQueryResponse>
    {

        private readonly UserManager<ModelUser> _userManager;

        public GetUserByNameQueryHandler(UserManager<ModelUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<GetUserByNameQueryResponse> Handle(GetUserByNameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                throw new NotFoundException("User Not Found");
            }

            return ObjectMapper.Mapper.Map<GetUserByNameQueryResponse>(user);
        }
    }
}
