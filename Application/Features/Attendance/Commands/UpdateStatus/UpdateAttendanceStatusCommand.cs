using Application.Abstractions.Messaging;
using Domain.Enums;
using Domain.Models.Attendance.Enums;

namespace Application.Features.Attendance.Commands.UpdateStatus;

public record UpdateAttendanceStatusCommand(
    Ulid AttendanceId,
    AttendanceStatus Status,
    string? Notes
) : ICommand<Ulid>;
