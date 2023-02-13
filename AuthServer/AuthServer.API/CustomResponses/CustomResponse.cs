
using System.Text.Json.Serialization;


namespace AuthServer.API.CustomResponses
{
    public class CustomResponse<T>
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }

        [JsonIgnore]
        public bool IsSuccessful { get; private set; }

        public ErrorResponse Error { get; private set; }

        public static CustomResponse<T> Success(T data, int statusCode)
        {
            return new CustomResponse<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }

        public static CustomResponse<T> Success(int statusCode)
        {
            return new CustomResponse<T> { Data = default, StatusCode = statusCode, IsSuccessful = true };
        }

        public static CustomResponse<T> Fail(ErrorResponse errorDto, int statusCode)
        {
            return new CustomResponse<T>
            {
                Error = errorDto,
                StatusCode = statusCode,
                IsSuccessful = false
            };
        }

        public static CustomResponse<T> Fail(string errorMessage, int statusCode, bool isShow)
        {
            var errorDto = new ErrorResponse(errorMessage, isShow);

            return new CustomResponse<T> { Error = errorDto, StatusCode = statusCode, IsSuccessful = false };
        }
    }
}
