using Domain.Enums;
using Domain.Models.Attendance.Enums;
using SharedKernel;

namespace Application.Features.Attendance.Dtos;

public record AttendanceDto(
    Ulid Id,
    Ulid EmployeeId,
    string EmployeeFullName,     // ← must be here
    Ulid? SectorId,
    string? SectorName,
    DateTime Date,
    DateTime? CheckInTime,
    DateTime? CheckOutTime,
    decimal HoursWorked,
    decimal HoursToWork,
    AttendanceStatus Status,
    bool IsConfirmed,
    string? Notes,
    Ulid UserId
);