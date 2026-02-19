using System;
using System.Collections.Generic;
using Domain.Enums;
using SharedKernel.Common;

namespace Domain.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProjectCode { get; set; }
        public Guid SectorId { get; set; }
        public Guid? ProjectManagerId { get; set; }
        public string Area { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? CompletionDate { get; set; }
        public ProjectStatus Status { get; set; }
        public decimal EstimatedBudget { get; set; }
        public decimal ActualCost { get; set; }
        public decimal CompletionPercentage { get; set; }

        public virtual Sector Sector { get; set; }
        public virtual User ProjectManager { get; set; }
        public virtual ICollection<ProjectTeam> ProjectTeams { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<Expense> Expenses { get; set; }


        public Project()
        {
            ProjectTeams = new HashSet<ProjectTeam>();
            Tasks = new HashSet<Task>();
            Expenses = new HashSet<Expense>();
        }
    }
}
