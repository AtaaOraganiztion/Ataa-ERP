using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Models.Attendance;
using SharedKernel;

namespace Application.Features.Attendance.Commands.Add;

public class AddAttendanceCommandHandler(
    IRepository<Domain.Models.Attendance.Attendance> repository)
    : ICommandHandler<AddAttendanceCommand, Ulid>
{
    public async Task<Result<Ulid>> Handle(
        AddAttendanceCommand request,
        CancellationToken cancellationToken)
    {
        // Always compute HoursWorked server-side from CheckIn/CheckOut
        decimal hoursWorked = 0;
        if (request.CheckInTime.HasValue && request.CheckOutTime.HasValue)
            hoursWorked = (decimal)(request.CheckOutTime.Value - request.CheckInTime.Value).TotalHours;

        var attendance = new Domain.Models.Attendance.Attendance
        {
            Id = Ulid.NewUlid(),
            EmployeeId = request.EmployeeId,
            Date = request.Date.Date,
            CheckInTime = request.CheckInTime,
            CheckOutTime = request.CheckOutTime,
            HoursWorked = hoursWorked,
            HoursToWork = request.HoursToWork,
            Status = request.Status,
            Notes = request.Notes,
            IsConfirmed = false,
            IsDeleted = false,
        };

        await repository.AddAsync(attendance, cancellationToken);

        return Result.Success(attendance.Id);
    }
}
