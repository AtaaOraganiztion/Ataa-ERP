using System;
using Domain.Enums;

namespace Application.DTOs
{
    public class LeaveDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public LeaveType LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalDays { get; set; }
        public string Reason { get; set; }
        public LeaveStatus Status { get; set; }
    }

    public class CreateLeaveDto
    {
        public Guid EmployeeId { get; set; }
        public LeaveType LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
    }

    public class ApproveLeaveDto
    {
        public Guid LeaveId { get; set; }
        public bool IsApproved { get; set; }
        public string RejectionReason { get; set; }
    }
}
