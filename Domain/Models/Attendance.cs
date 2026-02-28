using System;
using Domain.Entities;
using Domain.Enums;
using SharedKernel.Common;

namespace Domain.Models
{
    public class Attendance : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public Guid ProjectId { get; set; }
        public DateTime Date { get; set; }
        public DateTime? CheckInTime { get; set; }
        public DateTime? CheckOutTime { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal HoursToWork { get; set; }
        public AttendanceStatus Status { get; set; }
        public bool IsConfirmed { get; set; }
        public Guid? ConfirmedBy { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public string Notes { get; set; }

        public virtual Employee.Employee Employee { get; set; }
        public virtual Project Project { get; set; }
        public virtual User Confirmer { get; set; }
    }
}