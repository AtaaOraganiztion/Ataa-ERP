using Application.Features.Attendance.Dtos;
using Ardalis.Specification;
using Domain.Models.Attendance;

namespace Application.Features.Attendance.Specifications;

public class GetAttendanceSpec : Specification<Domain.Models.Attendance.Attendance>
{
    public GetAttendanceSpec(AttendanceFilter filter)
    {
        // Always include Employee -> Sector for name and sector resolution
        Query
            .Include(a => a.Employee)
                .ThenInclude(e => e.Sector);

        // Filter by sector — returns all employees belonging to that sector
        if (filter.SectorId is { } sectorId && sectorId != default)
            Query.Where(a => a.Employee.SectorId == sectorId);

        // Filter by specific employee
        if (filter.EmployeeId is { } employeeId && employeeId != default)
            Query.Where(a => a.EmployeeId == employeeId);

        // Filter by exact date (the date picker in the UI)
        if (filter.Date.HasValue)
            Query.Where(a => a.Date.Date == filter.Date.Value.Date);

        // Filter by status
        if (filter.Status.HasValue)
            Query.Where(a => a.Status == filter.Status.Value);

        Query.OrderBy(a => a.Employee.EmployeeFirstName);
    }
}
