using AD_CW_1.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Validators
{
    public class TransportUnitValidator : AbstractValidator<TransportUnitModel>
    {
        public TransportUnitValidator()
        {
            RuleFor(tu => tu.UnitNumber)
                 .NotEmpty().WithMessage("Unit number is required.")
                 .Length(1, 50).WithMessage("Unit number must be between 1 and 50 characters.");

            RuleFor(tu => tu.TruckId)
                .GreaterThan(0).WithMessage("Valid truck is required.");

            RuleFor(tu => tu.DriverId)
                .GreaterThan(0).WithMessage("Valid driver is required.");

            RuleFor(tu => tu.AssistantId)
                .NotNull().WithMessage("Assistant is required.")
                .GreaterThan(0).WithMessage("Valid assistant is required.");

            RuleFor(tu => tu.Status)
                .NotEmpty().WithMessage("Status is required.");

        }
    }
}
