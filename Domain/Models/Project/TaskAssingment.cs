using Domain.Entities;
using SharedKernel;
using SharedKernel.Common;
using System;

namespace Domain.Models.Project
{
    public class TaskAssignment : Entity, ISoftDeletableEntity
    {
        public Ulid? TaskId { get; set; }
        public Ulid? UserId { get; set; }
        public DateTime? AssignedDate { get; set; }
        public string Notes { get; set; } = null!;

        public virtual ProjectTask? Task { get; set; }
        public virtual User? User { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime DeletedOnUtc { get; set; }
    }
}