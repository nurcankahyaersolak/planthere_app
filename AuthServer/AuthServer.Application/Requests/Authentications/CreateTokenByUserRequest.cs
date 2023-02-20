namespace AuthServer.Application.Requests.Authentications
{
    public class CreateTokenByUserRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
