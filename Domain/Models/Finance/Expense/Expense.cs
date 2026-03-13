using Domain.Entities;
using Domain.Enums;
using Domain.Models;
using SharedKernel.Common;
using System;

namespace Domain.Models.Finance.Expense
{
    public class Expense : BaseEntity
    {
        public Ulid SectorId { get; set; }
        public Ulid? ProjectId { get; set; }
        public decimal ExpenseAmount { get; set; }
        public int SectorNumber { get; set; }
        public decimal Amount { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public DateTime ExpenseDate { get; set; }
        public string Description { get; set; } = null!;
        public string Category { get; set; } = null!;
        public ExpenseStatus Status { get; set; }
        public Ulid? RequestedBy { get; set; }
        public Ulid? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string RejectionReason { get; set; } = null!;
        public string ReceiptNumber { get; set; } = null!;
        public bool IsConfirmed { get; set; }
        public Ulid? ConfirmedBy { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }
        public decimal HoursWorked { get; set; }
        public bool Confirm { get; set; }
        public string Notes { get; set; } = null!;

        public virtual Sector.Sector? Sector { get; set; }
        public virtual Project? Project { get; set; }
        public virtual User? Requester { get; set; }
        public virtual User? Approver { get; set; }
        public virtual User? Confirmer { get; set; }
    }
}