using Domain.Enums;
using Domain.Models.Attendance.Enums;

namespace Application.Features.Attendance.Dtos;

public record UpdateAttendanceDto(
    Ulid Id,
    Ulid? EmployeeId,
    Ulid? SectorId,
    string? SectorName,
    Ulid? UserId,
    DateTime Date,
    DateTime? CheckInTime,
    DateTime? CheckOutTime,
    decimal? HoursWorked,
    decimal? HoursToWork,
    AttendanceStatus Status,
    bool IsConfirmed,
    string? Notes
);
 