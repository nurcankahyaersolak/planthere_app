namespace PlantHere.Application.Settings
{
    public class CustomTokenOption
    {
        public List<String> Audiences { get; set; }

        public string Issuer { get; set; }

        public string SecurityKey { get; set; }

    }
}
