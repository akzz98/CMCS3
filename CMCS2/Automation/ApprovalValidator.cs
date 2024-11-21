using CMCS2.Models;
using FluentValidation;

namespace CMCS3.Automation
{
    public class ApprovalValidator : AbstractValidator<Claim>
    {
        public ApprovalValidator()
        {
            // Ensure the claim is in the "Verified" status
            RuleFor(claim => claim.Status)
                .Equal("Verified").WithMessage("Claim must be in 'Verified' status to be approved.");

            // Check if the claim amount is within an acceptable range
            RuleFor(claim => claim)
                .Must(claim => claim.HoursWorked * claim.HourlyRate <= 100000)
                .WithMessage("Total claim amount cannot exceed \\R100,000.");

            // Ensure the claim has been verified by a coordinator
            RuleFor(claim => claim.CoordinatorFullName)
                .NotEmpty().WithMessage("Claim must be verified by a coordinator.");

            // Check if the claim has a valid verification date
            RuleFor(claim => claim.DateVerified)
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("Verification date must be in the past.");
        }
    }
}