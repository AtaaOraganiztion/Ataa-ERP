using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Enums;
using Domain.Models;
using SharedKernel;
using SharedKernel.Common;

namespace Domain.Models
{
    public class Project : Entity,ISoftDeletableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectCode { get; set; }
        public Ulid SectorId { get; set; }
        public Ulid? ProjectManagerId { get; set; }
        public string Area { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? CompletionDate { get; set; }
        public ProjectStatus Status { get; set; }
        public decimal EstimatedBudget { get; set; }
        public decimal ActualCost { get; set; }
        public decimal CompletionPercentage { get; set; }

        public virtual Sector.Sector Sector { get; set; }
        public virtual User ProjectManager { get; set; }
        public virtual ICollection<Finance.Expense.Expense> Expenses { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime DeletedOnUtc { get; set; }
    }
}