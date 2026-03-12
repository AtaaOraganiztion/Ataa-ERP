using Domain.Models;
using SharedKernel.Common;
using System;

namespace Domain.Models
{
    public class Enrollment : BaseEntity
    {
        public string EmployeeName { get; set; } = null!;
        public string JobType { get; set; }= null!;
        public Guid SectorId { get; set; }
        public Guid? ProjectId { get; set; }
        public bool IsConfirmed { get; set; }

        public virtual Sector? Sector { get; set; }
        public virtual Project.Project? Project { get; set; }
    }
}