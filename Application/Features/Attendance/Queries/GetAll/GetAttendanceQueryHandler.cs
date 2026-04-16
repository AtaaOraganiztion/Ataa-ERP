using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Attendance.Dtos;
using Application.Features.Attendance.Specifications;
using Domain.Models.Attendance;
using SharedKernel;

namespace Application.Features.Attendance.Queries.GetAll;

public class GetAttendanceQueryHandler(
    IRepository<Domain.Models.Attendance.Attendance> repository)
    : IQueryHandler<GetAttendanceQuery, List<AttendanceDto>>
{
    public async Task<Result<List<AttendanceDto>>> Handle(
        GetAttendanceQuery request,
        CancellationToken cancellationToken)
    {
        var attendances = await repository.ListAsync(
            new GetAttendanceSpec(request.Filter),
            cancellationToken);

        var result = attendances.Select(a => new AttendanceDto(
    a.Id,
    a.EmployeeId ?? Ulid.Empty,
    a.Employee != null
        ? a.Employee.EmployeeFirstName + " " + a.Employee.EmployeeLastName
        : "Unknown",
    a.Employee?.SectorId,
    a.Employee?.Sector?.Name,
    a.Date,
    a.CheckInTime,
    a.CheckOutTime,
    a.HoursWorked,
    a.HoursToWork,
    a.Status,
    a.IsConfirmed,
    a.Notes,
    a.UserId ?? Ulid.Empty
    )).ToList();

        return Result.Success(result);
    }
}