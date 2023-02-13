namespace AuthServer.API.CustomResponses
{
    public class ErrorResponse
    {
        public List<string> Errors { get; private set; }

        public bool IsShow { get; private set; }

        public ErrorResponse()
        {
            Errors = new List<string>();
        }

        public ErrorResponse(string error, bool isShow)
        {
            Errors = new List<string>();
            Errors.Add(error);
            IsShow = isShow;
        }

        public ErrorResponse(List<string> error, bool isShow)
        {
            Errors = error;
            IsShow = isShow;
        }
    }
}
