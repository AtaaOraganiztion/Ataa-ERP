using System;
using Domain.Enums;
using SharedKernel.Common;

namespace Domain.Entities
{
    public class Budget : BaseEntity
    {
        public Guid SectorId { get; set; }
        public int Year { get; set; }
        public decimal TotalBudget { get; set; }
        public decimal AllocatedAmount { get; set; }
        public decimal SpentAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal BudgetLimit { get; set; }
        public BudgetStatus Status { get; set; }
        public bool IsConfirmed { get; set; }
        public Guid? ConfirmedBy { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public string Notes { get; set; }

        public virtual Sector Sector { get; set; }
        public virtual User Confirmer { get; set; }
    }
}
