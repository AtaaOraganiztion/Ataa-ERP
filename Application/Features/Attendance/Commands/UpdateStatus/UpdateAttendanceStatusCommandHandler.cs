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
            return Result.Failure<Ulid>(Error.NotFound(AttendenceMessageKeys.AttendenceNotFound));

        // When marking absent clear times and hours — no work was done
        if (request.Status == AttendanceStatus.Absent)
        {
            attendance.CheckInTime = null;
            attendance.CheckOutTime = null;
            attendance.HoursWorked = 0;
        }

        attendance.Status = request.Status;

        if (request.Notes is not null)
            attendance.Notes = request.Notes;

        await repository.UpdateAsync(attendance, cancellationToken);

        return Result.Success(attendance.Id);
    }
}
