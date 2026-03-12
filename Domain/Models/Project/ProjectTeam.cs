using Domain.Entities;
using SharedKernel;
using SharedKernel.Common;
using System;

namespace Domain.Models.Project
{
    public class ProjectTeam : Entity, ISoftDeletableEntity
    {
        public Ulid? ProjectId { get; set; }
        public Ulid? UserId { get; set; }
        public string Role { get; set; } = null!;
        public DateTime? AssignedDate { get; set; }
        public DateTime? RemovedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Project? Project { get; set; }
        public virtual User? User { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime DeletedOnUtc { get; set; }
    }
}