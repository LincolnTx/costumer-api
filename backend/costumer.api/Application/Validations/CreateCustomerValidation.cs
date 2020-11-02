using costumer.api.Infra.Extensions;
using costumer.api.v1.Contracts;
using FluentValidation;

namespace costumer.api.Application.Validations
{
    public class CreateCustomerValidation : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerValidation()
        {
            ValidateName();
            ValidateEmail();
            ValidateCpf();
        }

        protected void ValidateName()
        {
            RuleFor(customer => customer.Name)
                .NotEmpty().WithMessage("Campo nome obrigatório").WithErrorCode("001");
        }

        protected void ValidateEmail()
        {
            RuleFor(customer => customer.Email)
                .NotEmpty().WithMessage("Campo email obrigatório").WithErrorCode("002")
                .EmailAddress().WithMessage("O campo precisa ser um email válido").WithErrorCode("003");
        }

        protected void ValidateCpf()
        {
            RuleFor(customer => customer.CpfCnpj)
                .NotEmpty().MinimumLength(11).WithMessage("Campo Cpf/Cnpj deve ter no mínimo 11 caracteres").WithErrorCode("004");
            
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
