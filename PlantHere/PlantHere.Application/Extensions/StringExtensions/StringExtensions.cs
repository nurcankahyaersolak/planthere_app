namespace PlantHere.Application.Extensions.StringExtensions
{
    public static class StringExtensions
    {
        public static string GetModelName(this string fullName)
        {
            var splitArray = fullName?.Split('.').ToList();
            if (splitArray?.Count > 3) return splitArray[3];
            return string.Empty;
        }
    }
}
