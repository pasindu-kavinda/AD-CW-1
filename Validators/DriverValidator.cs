using AD_CW_1.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Validators
{
    public class DriverValidator : AbstractValidator<DriverModel>
    {
        public DriverValidator()
        {
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Driver name is required.")
                .Length(1, 100).WithMessage("Driver name must be between 1 and 100 characters.");

            RuleFor(d => d.LicenseNumber)
                .NotEmpty().WithMessage("License number is required.")
                .Length(1, 50).WithMessage("License number must be between 1 and 50 characters.");

            RuleFor(d => d.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .MaximumLength(20).WithMessage("Phone number cannot exceed 20 characters.");

            RuleFor(d => d.Address)
                .NotEmpty().WithMessage("Address is required.")
                .MaximumLength(500).WithMessage("Address cannot exceed 500 characters.");

            RuleFor(d => d.Status)
                .NotEmpty().WithMessage("Status is required.");

        }
    }
}
