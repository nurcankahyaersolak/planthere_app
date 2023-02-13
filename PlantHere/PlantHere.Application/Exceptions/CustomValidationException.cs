using FluentValidation.Results;

namespace PlantHere.Application.Exceptions
{
    [Serializable]
    public class CustomValidationException : Exception
    {
        public IEnumerable<ValidationFailure> Errors { get; private set; }

        public CustomValidationException(string message, IEnumerable<ValidationFailure> errors, bool appendDefaultMessage) : base(appendDefaultMessage ? $"{message} {BuildErrorMessage(errors)}" : message)
        {
            Errors = errors;
        }

        private static string BuildErrorMessage(IEnumerable<ValidationFailure> errors)
        {
            var message = $"Validation Failed : PropertyName : {errors.FirstOrDefault().PropertyName} , ErrorMessage : {errors.FirstOrDefault().ErrorMessage}";

            return message;
        }

    }
}
