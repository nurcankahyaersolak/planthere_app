using System.Text.Json.Serialization;

namespace PlantHere.WebAPI.CustomResults
{
    public class NoContentResult
    {
        public List<String> Errors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public static NoContentResult Success(int statusCode)
        {
            return new NoContentResult { StatusCode = statusCode };
        }
    }
}
