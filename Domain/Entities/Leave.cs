using System;
using Domain.Enums;
using SharedKernel.Common;

namespace Domain.Entities
{
    public class Leave : BaseEntity
    {
        public Guid EmployeeId { get; set; }
        public LeaveType LeaveType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalDays { get; set; }
        public string Reason { get; set; }
        public LeaveStatus Status { get; set; }
        public Guid? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string RejectionReason { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual User Approver { get; set; }
    }
}
