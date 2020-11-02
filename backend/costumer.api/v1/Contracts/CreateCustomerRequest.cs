using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using costumer.api.Application.Validations;

namespace costumer.api.v1.Contracts
{
    public class CreateCustomerRequest : Request
    {
        public string Name { get; set; }
        public string CpfCnpj { get; set; }
        public string CompanyName { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
        public int Stage { get; set; }
        public List<string> Phones { get; set; }
        public override bool IsValid()
        {
            ValidationResult = new CreateCustomerValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
