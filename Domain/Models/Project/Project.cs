using Domain.Entities;
using Domain.Enums;
using Domain.Models.Finance.Expense;
using SharedKernel;
using SharedKernel.Common;
using System;
using System.Collections.Generic;

namespace Domain.Models.Project
{
    public class Project : Entity, ISoftDeletableEntity
    {
        public string ProjectName { get; set; } = null!;
        public string ProjectCode { get; set; } = null!;
        public string Description { get; set; }=null!;
        public string Area { get; set; } = null!;
        public Ulid? SectorId { get; set; }
        public Ulid? ProjectManagerId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? CompletionDate { get; set; }
        public ProjectStatus? Status { get; set; }
        public decimal? EstimatedBudget { get; set; }
        public decimal? ActualCost { get; set; }
        public decimal? CompletionPercentage { get; set; }

        public virtual Sector? Sector { get; set; }
        public virtual User? ProjectManager { get; set; }
        public virtual IEnumerable<ProjectTeam>? ProjectTeams { get; set; }
        public virtual IEnumerable<ProjectTask>? Tasks { get; set; }
        public virtual IEnumerable<Expense>? Expenses { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime DeletedOnUtc { get; set; }
    }
}