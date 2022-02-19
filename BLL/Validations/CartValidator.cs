using BLL.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validations
{
    public class CartValidator : AbstractValidator<CartDTO>
    {
        public CartValidator()
        {
            RuleFor(c => c.Title).NotEmpty().NotNull().Matches(@"^[A-Z].*$").WithMessage("The property {PropertyTitle} must begin with upper case");
        }
    }
}
