using Application.Abstractions.Messaging;
using Domain.Enums;
using Domain.Models.Attendance.Enums;

namespace Application.Features.Attendance.Commands.Add;

public record AddAttendanceCommand(
    Ulid EmployeeId,
    DateTime Date,
    DateTime? CheckInTime,
    DateTime? CheckOutTime,
    decimal HoursToWork,
    AttendanceStatus Status,
    string? Notes
) : ICommand<Ulid>;
