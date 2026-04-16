using FluentValidation;

namespace Application.Features.Attendance.Commands.Add;

public class AddAttendanceValidator : AbstractValidator<AddAttendanceCommand>
{
    public AddAttendanceValidator()
    {



        
        RuleFor(x => x.CheckOutTime)
            .GreaterThan(x => x.CheckInTime!.Value)
            .When(x => x.CheckInTime.HasValue && x.CheckOutTime.HasValue)
            .WithMessage("Check-out time must be after check-in time.");
        
        RuleFor(x => x.Notes)
            .MaximumLength(500).WithMessage("Notes must be at most 500 characters.")
            .When(x => x.Notes != null);
    }
}
