using FluentValidation.Results;

namespace costumer.api.v1.Contracts
{
    public abstract class Request
    {
        protected ValidationResult ValidationResult { get; set; }
        public ValidationResult GetValidationResult()
        {
            return ValidationResult;
        }
        public abstract bool IsValid();
    }
}
