using costumer.api.Application.Validations;

namespace costumer.api.v1.Contracts
{
    public class UpdateCustomerRequest : Request
    {
        public string CpfCnpj { get; set; }
        public int? Stage { get; set; }
        public string CompanyName { get; set; }
        public string ZipCode { get; set; }
        
        public override bool IsValid()
        {
            ValidationResult = new UpdateCustomerValidation().Validate(this);
            
            return ValidationResult.IsValid;
        }
    }
}