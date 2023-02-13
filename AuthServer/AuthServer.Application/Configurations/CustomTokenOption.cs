namespace AuthServer.Application.Configurations
{
    public class CustomTokenOption
    {
        public List<String> Audiences { get; set; }

        public string Issuer { get; set; }

        public int AccessTokenExpiration { get; set; }

        public int RefreshTokenExpiration { get; set; }

        public string SecurityKey { get; set; }

    }
}
