using Domain.Enums;
using Domain.Models.Attendance.Enums;

namespace Application.Features.Attendance.Dtos;

public record AttendanceFilter(
    Ulid? SectorId,
    Ulid? EmployeeId,
    DateTime? Date,
    AttendanceStatus? Status
);
