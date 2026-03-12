using Domain.Models;
using SharedKernel.Common;
using System;
using Domain.Models.Project;

namespace Domain.Models
{
    public class Profit : BaseEntity
    {
        public Guid? ProjectId { get; set; }
        public Guid? SectorId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal Revenue { get; set; }
        public decimal TotalCost { get; set; }
        public decimal ProfitAmount { get; set; }
        public decimal ProfitMargin { get; set; }
        public decimal TotalBudget { get; set; }
        public string Notes { get; set; } = null!;

        public virtual Project.Project? Project { get; set; }
        public virtual Sector? Sector { get; set; }
    }
}