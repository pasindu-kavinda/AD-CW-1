using AD_CW_1.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Validators
{
    public class JobProductValidator : AbstractValidator<JobProductModel>
    {
        public JobProductValidator()
        {
            RuleFor(jp => jp.JobId)
                .NotNull().WithMessage("Job is required.");

            RuleFor(jp => jp.ProductId)
                .NotNull().WithMessage("Product is required.");

            RuleFor(jp => jp.Quantity)
                .NotNull().WithMessage("Quantity is required.")
                .When(jp => jp.Quantity.HasValue);

            RuleFor(jp => jp.CustomWeight)
                .NotNull().WithMessage("Custom weight is required.")
                .When(jp => jp.CustomWeight.HasValue);

            RuleFor(jp => jp.CustomDimensions)
                .MaximumLength(100).WithMessage("Custom dimensions cannot exceed 100 characters.")
                .When(jp => !string.IsNullOrEmpty(jp.CustomDimensions));
        }
    }
}
