using System;
using System.Collections.Generic;
using Domain.Enums;
using SharedKernel.Common;

namespace Domain.Entities
{
    public class Task : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public TaskStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? CompletedDate { get; set; }
        public decimal EstimatedHours { get; set; }
        public decimal ActualHours { get; set; }

        public virtual Project Project { get; set; }
        public virtual ICollection<TaskAssignment> TaskAssignments { get; set; }

        public Task()
        {
            TaskAssignments = new HashSet<TaskAssignment>();
        }
    }
}
