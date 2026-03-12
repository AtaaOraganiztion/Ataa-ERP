using System;
using System.Collections.Generic;
using Domain.Enums;
using SharedKernel;
using SharedKernel.Common;

namespace Domain.Models.Project.Project
{
    public class ProjectTask : Entity, ISoftDeletableEntity
    {
        public Ulid? ProjectId { get; set; }
        public string TaskName { get; set; } = null!;
        public string Description { get; set; } = null!;
        //public TaskStatus.TaskStatus? Status { get; set; }
        public TaskPriority? Priority { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? Deadline { get; set; }
        public DateTime? CompletedDate { get; set; }
        public decimal? EstimatedHours { get; set; }
        public decimal? ActualHours { get; set; }
        public Ulid? ParentTaskId { get; set; }

        public virtual Project? Project { get; set; }
        public virtual ProjectTask? ParentTask { get; set; }
        public virtual IEnumerable<ProjectTask>? SubTasks { get; set; }
        public virtual IEnumerable<TaskAssignment>? TaskAssignments { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime DeletedOnUtc { get; set; }
    }
}