using AD_CW_1.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Validators
{
    public class LoadValidator : AbstractValidator<LoadModel>
    {
        public LoadValidator()
        {
            RuleFor(l => l.LoadNumber)
                .NotEmpty().WithMessage("Load number is required.")
                .Length(1, 50).WithMessage("Load number must be between 1 and 50 characters.");

            RuleFor(l => l.JobId)
                .GreaterThan(0).WithMessage("Valid job is required.");

            RuleFor(l => l.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(l => l.Weight)
                .GreaterThan(0).WithMessage("Weight must be greater than zero.");

            RuleFor(l => l.Volume)
                .GreaterThan(0).WithMessage("Volume must be greater than zero.");

            RuleFor(l => l.Instructions)
                .MaximumLength(500).WithMessage("Instructions cannot exceed 500 characters.")
                .When(l => !string.IsNullOrEmpty(l.Instructions));
        }
    }
}
