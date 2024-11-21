using CMCS2.Models;
using FluentValidation;

namespace CMCS3.Automation
{
    public class ClaimValidator : AbstractValidator<Claim>
    {
        public ClaimValidator()
        {
            RuleFor(claim => claim.HoursWorked)
                .GreaterThanOrEqualTo(80).WithMessage("Hours worked must be at least 80.")
                .LessThanOrEqualTo(160).WithMessage("Hours worked cannot exceed 160.");

            RuleFor(claim => claim.HourlyRate)
                .GreaterThanOrEqualTo(125).WithMessage("Hourly rate must be at least \\R125.")
                .LessThanOrEqualTo(291).WithMessage("Hourly rate cannot exceed \\R291.");

            RuleFor(claim => claim)
                .Must(claim => claim.HoursWorked * claim.HourlyRate <= 50000)
                .WithMessage("Total claim amount cannot exceed \\R50,000.");

            RuleFor(claim => claim.DocumentPath)
                .NotEmpty().WithMessage("A supporting document must be uploaded.");

            RuleFor(claim => claim.DocumentPath)
                .Must(path => new[] { ".pdf", ".jpg", ".png" }.Contains(Path.GetExtension(path).ToLower()))
                .WithMessage("Only .pdf, .jpg, and .png files are allowed.");
        }
    }
}
