using Domain.Entities;
using Domain.Enums;
using Domain.Models;
using SharedKernel.Common;
using System;
using System.Collections.Generic;

namespace Domain.Models.Finance.Budget
{
    public class Budget : BaseEntity
    {
        public Guid? SectorId { get; set; }
        public int Year { get; set; } 
        public decimal EstimatedBudget { get; set; }
        public bool IsConfirmed { get; set; }
        public decimal Limit { get; set; }
        public decimal TotalBudget { get; set; }
        public decimal AllocatedAmount { get; set; }
        public decimal SpentAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal BudgetLimit { get; set; }
        public BudgetStatus Status { get; set; }
        public Guid? ConfirmedBy { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public string Notes { get; set; }

        public virtual Sector.Sector? Sector { get; set; }
        public virtual User? Confirmer { get; set; }
        public virtual ICollection<BudgetAllocation> BudgetAllocations { get; set; }


        public Budget()
        {
            BudgetAllocations = new HashSet<BudgetAllocation>();
        }
    }
}