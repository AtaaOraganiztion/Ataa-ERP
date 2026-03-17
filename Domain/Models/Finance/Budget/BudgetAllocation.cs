using System;
using SharedKernel;
using Domain.Models.Finance.Budget;

namespace Domain.Models.Finance.Budget
{
    public class BudgetAllocation : Entity, ISoftDeletableEntity
    {
        public Ulid? BudgetId { get; set; }
        public string Category { get; set; } = null!;
        public decimal? AllocatedAmount { get; set; }
        public decimal? SpentAmount { get; set; }
        public string Description { get; set; } = null!;

        public virtual Finance.Budget.Budget? Budget { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime DeletedOnUtc { get; set; }
    }
}