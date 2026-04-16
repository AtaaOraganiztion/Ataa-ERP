using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Enums;
using Domain.Models.Attendance;
using Domain.Models.Attendance.Enums;
using SharedKernel;

namespace Application.Features.Attendance.Commands.UpdateStatus;

public class UpdateAttendanceStatusCommandHandler(
    IRepository<Domain.Models.Attendance.Attendance> repository)
    : ICommandHandler<UpdateAttendanceStatusCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(
        UpdateAttendanceStatusCommand request,
        CancellationToken cancellationToken)
    {
        var attendance = await repository.GetByIdAsync(request.AttendanceId, cancellationToken);

        if (attendance is null)
            return Result.Failure<Ulid>(
                Error.NotFound(AttendenceMessageKeys.AttendenceNotFound));

        // Update basic fields
        attendance.Status = request.Status;

        if (request.Notes is not null)
            attendance.Notes = request.Notes;

        // Update CheckIn / CheckOut if provided
        if (request.CheckInTime.HasValue)
            attendance.CheckInTime = request.CheckInTime;

        if (request.CheckOutTime.HasValue)
            attendance.CheckOutTime = request.CheckOutTime;

        // Recalculate HoursWorked safely
        if (attendance.CheckInTime.HasValue && attendance.CheckOutTime.HasValue)
        {
            attendance.HoursWorked =
                (decimal)(attendance.CheckOutTime.Value - attendance.CheckInTime.Value)
                .TotalHours;
        }

        // Business rule: Absent resets everything
        if (request.Status == AttendanceStatus.Absent)
        {
            attendance.CheckInTime = null;
            attendance.CheckOutTime = null;
            attendance.HoursWorked = 0;
        }

        await repository.UpdateAsync(attendance, cancellationToken);

        return Result.Success(attendance.Id);
    }
}