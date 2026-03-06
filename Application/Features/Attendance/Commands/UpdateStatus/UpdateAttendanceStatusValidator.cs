using FluentValidation;

namespace Application.Features.Attendance.Commands.UpdateStatus;

public class UpdateAttendanceStatusValidator : AbstractValidator<UpdateAttendanceStatusCommand>
{
    public UpdateAttendanceStatusValidator()
    {
        RuleFor(x => x.AttendanceId)
            .NotEmpty().WithMessage("Attendance ID is required.");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid attendance status.");

        RuleFor(x => x.Notes)
            .MaximumLength(500).WithMessage("Notes must be at most 500 characters.")
            .When(x => x.Notes != null);
    }
}
