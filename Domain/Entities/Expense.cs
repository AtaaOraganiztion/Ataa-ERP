using System;
using Domain.Enums;
using SharedKernel.Common;

namespace Domain.Entities
{
    public class Expense : BaseEntity
    {
        public Guid SectorId { get; set; }
        public Guid? ProjectId { get; set; }
        public decimal Amount { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public ExpenseStatus Status { get; set; }
        public Guid? RequestedBy { get; set; }
        public Guid? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string RejectionReason { get; set; }
        public string ReceiptNumber { get; set; }
        public bool IsConfirmed { get; set; }
        public Guid? ConfirmedBy { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }
        public string Notes { get; set; }

        public virtual Sector Sector { get; set; }
        public virtual Project Project { get; set; }
        public virtual User Requester { get; set; }
        public virtual User Approver { get; set; }
        public virtual User Confirmer { get; set; }
    }
}
