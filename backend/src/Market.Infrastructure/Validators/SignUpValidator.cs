using FluentValidation;
using Market.Application.Users.Commands;

namespace Market.Infrastructure.Validators
{
    public class SignUpValidator : AbstractValidator<SignUp>
    {
        public SignUpValidator()
        {
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
            RuleFor(c => c.Password).NotEmpty();
        }
    }
}