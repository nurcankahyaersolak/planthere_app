using MediatR;

namespace AuthServer.Application.CQRS.User.Queries.GetUserByName
{
    public class GetUserByNameQuery : IRequest<GetUserByNameQueryResponse>
    {
        public string UserName { get; set; }

        public GetUserByNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
