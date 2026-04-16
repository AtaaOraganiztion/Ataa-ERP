using Application.Features.Attendance.Dtos;
using Ardalis.Specification;
using Domain.Models.Attendance;

namespace Application.Features.Attendance.Specifications;

public class GetAttendanceSpec : Specification<Domain.Models.Attendance.Attendance>
{
    public GetAttendanceSpec(AttendanceFilter filter)
    {
        Query
            .Include(a => a.Employee)
                .ThenInclude(e => e.Sector);

        if (filter.SectorId is { } sectorId && sectorId != default)
        {
            Query.Where(a =>
                a.Employee != null &&
                a.Employee.SectorId == sectorId);
        }

        if (filter.EmployeeId is { } employeeId && employeeId != default)
        {
            Query.Where(a => a.EmployeeId == employeeId);
        }

        if (filter.Date.HasValue)
        {
            var date = filter.Date.Value.Date;
            Query.Where(a => a.Date.Date == date);
        }
        if (filter.UserId is { } userId && userId != default)
        {
            Query.Where(a => a.UserId == userId);
        }

        if (filter.Status.HasValue)
        {
            Query.Where(a => a.Status == filter.Status.Value);
        }

       
        Query.OrderBy(a =>
            a.Employee != null
                ? a.Employee.EmployeeFirstName
                : string.Empty);
    }
}