using AD_CW_1.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_CW_1.Validators
{
    public class JobValidator : AbstractValidator<JobModel>
    {
        public JobValidator()
        {
            RuleFor(j => j.JobNumber)
                .NotEmpty().WithMessage("Job number is required.")
                .Length(1, 50).WithMessage("Job number must be between 1 and 50 characters.");

            RuleFor(j => j.CustomerId)
                .GreaterThan(0).WithMessage("Valid customer is required.");

            RuleFor(j => j.PickupLocation)
                .NotEmpty().WithMessage("Pickup location is required.")
                .MaximumLength(500).WithMessage("Pickup location cannot exceed 500 characters.");

            RuleFor(j => j.DeliveryLocation)
                .NotEmpty().WithMessage("Delivery location is required.")
                .MaximumLength(500).WithMessage("Delivery location cannot exceed 500 characters.");

            RuleFor(j => j.RequestDate)
                .NotEmpty().WithMessage("Request date is required.");

            RuleFor(j => j.EstimatedCost)
                .NotNull().WithMessage("Estimated cost is required.")
                .GreaterThanOrEqualTo(0).WithMessage("Estimated cost cannot be negative.");

            RuleFor(j => j.ActualCost)
                .GreaterThanOrEqualTo(0).WithMessage("Actual cost cannot be negative.")
                .When(j => j.ActualCost != null);

            RuleFor(j => j.Description)
                .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.")
                .When(j => !string.IsNullOrEmpty(j.Description));

            RuleFor(j => j.Notes)
                .MaximumLength(1000).WithMessage("Notes cannot exceed 1000 characters.")
                .When(j => !string.IsNullOrEmpty(j.Notes));


            RuleFor(j => j.Status)
                .NotEmpty().WithMessage("Status is required.");

        }
    }
}
