using costumer.api.Application.Validations;

namespace costumer.api.v1.Contracts
{
    public class LoginRequest : Request
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public override bool IsValid()
        {
            ValidationResult = new LoginValidation().Validate(this);
            
            return ValidationResult.IsValid;
        }
    }
}
