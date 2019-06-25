using FluentValidation;
using Market.Application.Products.Commands;

namespace Market.Infrastructure.Validators
{
    public class CreateProductValidator : AbstractValidator<CreateProduct>
    {
        public CreateProductValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Category).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Price).GreaterThan(0);
        }
    }
}