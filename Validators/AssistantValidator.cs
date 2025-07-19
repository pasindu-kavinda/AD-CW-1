using AD_CW_1.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Validators
{
    public class AssistantValidator : AbstractValidator<AssistantModel>
    {
        public AssistantValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("Assistant name is required.")
                .Length(1, 100).WithMessage("Assistant name must be between 1 and 100 characters.");

            RuleFor(a => a.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters.");

            RuleFor(a => a.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(500).WithMessage("Address cannot exceed 500 characters.");

            RuleFor(d => d.Status)
                .NotEmpty().WithMessage("Status is required.");

        }
    }
}
