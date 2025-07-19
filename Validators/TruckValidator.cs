using AD_CW_1.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Validators
{
    public class TruckValidator : AbstractValidator<TruckModel>
    {
        public TruckValidator()
        {
            RuleFor(t => t.TruckNumber)
                .NotEmpty().WithMessage("Truck number is required.")
                .MaximumLength(50).WithMessage("Truck number cannot exceed 50 characters.");

            RuleFor(t => t.Model)
                .NotEmpty().WithMessage("Model is required.")
                .MaximumLength(100).WithMessage("Model cannot exceed 100 characters.");

            RuleFor(t => t.LicensePlate)
                .NotEmpty().WithMessage("License plate is required.")
                .MaximumLength(20).WithMessage("License plate cannot exceed 20 characters.");

            RuleFor(t => t.Status)
                .NotEmpty().WithMessage("Status is required.")
                .MaximumLength(20).WithMessage("Status cannot exceed 20 characters.");

            RuleFor(t => t.Capacity)
                .GreaterThan(0).WithMessage("Capacity must be greater than 0.");
        }
    }
}
