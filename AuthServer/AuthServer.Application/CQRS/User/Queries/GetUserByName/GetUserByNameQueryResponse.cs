namespace AuthServer.Application.CQRS.User.Queries.GetUserByName
{
    public class GetUserByNameQueryResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
