using AD_CW_1.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Validators
{
    public class ProductValidator : AbstractValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(255).WithMessage("Product name cannot exceed 255 characters.");

            RuleFor(p => p.Weight)
                .NotNull().WithMessage("Weight is required.")
                .GreaterThan(0).WithMessage("Weight cannot be negative.");

            RuleFor(p => p.Dimensions)
                .NotNull().WithMessage("Dimensions are required.");

        }
    }
}
