using costumer.api.Infra.Extensions;
using costumer.api.v1.Contracts;
using FluentValidation;

namespace costumer.api.Application.Validations
{
    public class UpdateCustomerValidation : AbstractValidator<UpdateCustomerRequest>
    {
        public UpdateCustomerValidation()
        {
            ValidateCpf();
        }

        
        protected void ValidateCpf()
        {
            RuleFor(customer => customer.CpfCnpj).Empty();
            
            RuleFor(customer => customer).Custom((customer, context) =>
            {
                if (customer.CpfCnpj.Length == 14 && !(CpfCnpjValidateHelper.ValidateCnpj(customer.CpfCnpj)))
                {
                    context.AddFailure(nameof(customer.CpfCnpj), "CNPJ inválido!");
                }

                if(customer.CpfCnpj.Length == 11 && !(CpfCnpjValidateHelper.ValidateCpf(customer.CpfCnpj)))
                {
                    context.AddFailure(nameof(customer.CpfCnpj), "CPF inválido!");
                }
            });
        }
    }
}