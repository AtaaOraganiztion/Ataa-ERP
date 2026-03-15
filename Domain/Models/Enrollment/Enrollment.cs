using Domain.Models;
using SharedKernel.Common;
using System;
using SharedKernel;

namespace Domain.Models
{
    public class Enrollment : Entity,ISoftDeletableEntity
    {
        public string EmployeeName { get; set; } = null!;
        public string JobType { get; set; }= null!;
        public Ulid SectorId { get; set; }
        public Ulid? ProjectId { get; set; }
        public bool IsConfirmed { get; set; }

        public virtual Sector.Sector? Sector { get; set; }
        public virtual Project? Project { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeletedOnUtc { get; set; }
    }
}