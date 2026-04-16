using Domain.Models.Attendance.Enums;

namespace Application.Features.Attendance.Dtos;

public record AttendanceFilter(
    Ulid? SectorId = null,
    Ulid? EmployeeId = null,
    DateTime? Date = null,
    Ulid? UserId = null,
    AttendanceStatus? Status = null,
    DateTime? CheckInFrom = null,
    DateTime? CheckInTo = null
);