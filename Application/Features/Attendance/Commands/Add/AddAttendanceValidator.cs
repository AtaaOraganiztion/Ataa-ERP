using FluentValidation;

namespace Application.Features.Attendance.Commands.Add;

public class AddAttendanceValidator : AbstractValidator<AddAttendanceCommand>
{
    public AddAttendanceValidator()
    {
        RuleFor(x => x.EmployeeId)
            .NotEmpty().WithMessage("Employee ID is required.");

        RuleFor(x => x.Date)
            .NotEmpty().WithMessage("Date is required.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Date cannot be in the future.");

        RuleFor(x => x.HoursToWork)
            .GreaterThan(0).WithMessage("Expected hours must be greater than 0.")
            .LessThanOrEqualTo(24).WithMessage("Expected hours cannot exceed 24.");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid attendance status.");

        RuleFor(x => x.CheckOutTime)
            .GreaterThan(x => x.CheckInTime)
            .When(x => x.CheckInTime.HasValue && x.CheckOutTime.HasValue)
            .WithMessage("Check-out time must be after check-in time.");

        RuleFor(x => x.Notes)
            .MaximumLength(500).WithMessage("Notes must be at most 500 characters.")
            .When(x => x.Notes != null);
    }
}
