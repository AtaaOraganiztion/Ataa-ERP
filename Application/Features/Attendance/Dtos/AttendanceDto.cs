using Domain.Enums;
using Domain.Models.Attendance.Enums;
using SharedKernel;

namespace Application.Features.Attendance.Dtos;

public record AttendanceDto
{
    public Ulid Id { get; init; }
    public Ulid EmployeeId { get; init; }
    public string EmployeeFullName { get; init; } = string.Empty;
    public Ulid? SectorId { get; init; }
    public string? SectorName { get; init; }
    public DateTime Date { get; init; }
    public DateTime? CheckInTime { get; init; }
    public DateTime? CheckOutTime { get; init; }
    public decimal HoursWorked { get; init; }
    public decimal HoursToWork { get; init; }
    public AttendanceStatus Status { get; init; }
    public bool IsConfirmed { get; init; }
    public string? Notes { get; init; }
}
