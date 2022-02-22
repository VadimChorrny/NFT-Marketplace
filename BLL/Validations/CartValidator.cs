using Core.DTOs;
using FluentValidation;

namespace Core.Validations
{
    public class CartValidator : AbstractValidator<CartDTO>
    {
        public CartValidator()
        {
            RuleFor(c => c.Title).NotEmpty().NotNull().Matches(@"^[A-Z].*$").WithMessage("The property {PropertyTitle} must begin with upper case");
        }
    }
}
