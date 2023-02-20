namespace AuthServer.Application.Requests.Users
{
    public class CreateUserRolesRequest
    {
        public string Email { get; set; }

        public List<string> Roles { get; set; }
    }
}
