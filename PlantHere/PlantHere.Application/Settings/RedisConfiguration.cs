namespace PlantHere.Application.Settings
{
    public class RedisConfiguration
    {
        public string Url { get; set; }

        public string Port { get; set; }

        public string Host { get; set; }

        public int Expiration { get; set; }
    }
}
