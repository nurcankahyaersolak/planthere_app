namespace PlantHere.Application.Exceptions
{
    [Serializable]
    public class ConflictException : Exception
    {
        public ConflictException(string message) : base(message)
        {
        }
    }
}
