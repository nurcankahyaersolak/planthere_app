namespace AuthServer.Application.Requests.Authentications
{
    public class CreateTokenByRefreshTokenRequest
    {
        public string RefreshToken { get; set; }

        public CreateTokenByRefreshTokenRequest(string refreshToken)
        {
            RefreshToken = refreshToken;
        }
    }
}
