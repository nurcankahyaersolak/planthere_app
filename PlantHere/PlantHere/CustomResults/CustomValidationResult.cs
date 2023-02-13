using FluentValidation;
using PlantHere.Application.Exceptions;
using System.Text.Json.Serialization;

namespace PlantHere.WebAPI.CustomResults
{
    public class CustomValidationResult<T>
    {
        private readonly IEnumerable<IValidator<T>> _validators;

        public CustomValidationResult(IEnumerable<IValidator<T>> validators)
        {
            _validators = validators;
        }

        public List<String> Errors { get; set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        public async Task<CustomValidationException> IsValid(T request, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<T>(request);
            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

            if (failures.Count != 0) return new CustomValidationException("", failures, true);
            else return null;
        }
    }
}
