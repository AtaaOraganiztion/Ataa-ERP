using System;
using Domain.Enums;

namespace Application.DTOs
{
    public class AttendanceDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal HoursToWork { get; set; }
        public AttendanceStatus Status { get; set; }
        public bool IsConfirmed { get; set; }
    }

    public class CreateAttendanceDto
    {
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal HoursToWork { get; set; }
        public AttendanceStatus Status { get; set; }
        public string Notes { get; set; }
    }

    public class ConfirmAttendanceDto
    {
        public Guid AttendanceId { get; set; }
        public bool IsApproved { get; set; }
        public string Notes { get; set; }
    }
}
