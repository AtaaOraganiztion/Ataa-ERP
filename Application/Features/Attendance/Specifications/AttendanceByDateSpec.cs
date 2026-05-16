using Ardalis.Specification;
using Domain.Models.Attendance;

namespace Application.Features.Attendance.Specifications;

public class AttendanceByDateSpec : Specification<Domain.Models.Attendance.Attendance>
{
    public AttendanceByDateSpec(DateTime date)
    {
        Query.Where(a => a.Date.Date == date.Date);
    }
}
