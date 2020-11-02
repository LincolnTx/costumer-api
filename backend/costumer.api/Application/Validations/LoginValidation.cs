using costumer.api.v1.Contracts;
using FluentValidation;

namespace costumer.api.Application.Validations
{
    public class LoginValidation : AbstractValidator<LoginRequest>
    {
        public LoginValidation()
        {
            ValidateEmail();
            ValidatePassword();
        }

        protected void ValidateEmail()
        {
            RuleFor(login => login.Email)
                .NotEmpty().WithMessage("Campo email obrigatório").WithErrorCode("001")
                .EmailAddress().WithMessage("O campo precisa ser um email válido").WithErrorCode("001");
        }

        protected void ValidatePassword()
        {
            RuleFor(login => login.Password)
                .NotEmpty().WithMessage("Campo senha é obrigatório").WithErrorCode("003")
                .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caratcetres").WithErrorCode("002");
        }
    }
}
