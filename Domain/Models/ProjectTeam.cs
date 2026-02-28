using System;
using Domain.Entities;
using SharedKernel.Common;

namespace Domain.Models
{
    public class ProjectTeam : BaseEntity
    {
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public string Role { get; set; }
        public DateTime? AssignedDate { get; set; }
        public DateTime? RemovedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
}