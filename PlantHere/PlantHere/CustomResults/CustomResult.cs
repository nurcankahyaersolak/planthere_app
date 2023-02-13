
using System.Text.Json.Serialization;


namespace PlantHere.WebAPI.CustomResults
{
    public class CustomResult<T>
    {
        public T Data { get; private set; }

        public List<String> Errors { get; private set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public static CustomResult<T> Success(int statusCode, T data)
        {
            return new CustomResult<T> { StatusCode = statusCode, Data = data };
        }

        public static CustomResult<T> Success(int statusCode)
        {
            return new CustomResult<T> { StatusCode = statusCode };
        }

        public static CustomResult<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResult<T> { StatusCode = statusCode, Errors = errors };
        }

        public static CustomResult<T> Fail(int statusCode, string error)
        {
            return new CustomResult<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
