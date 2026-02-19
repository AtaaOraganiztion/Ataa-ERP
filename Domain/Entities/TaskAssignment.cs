using System;
using SharedKernel.Common;

namespace Domain.Entities
{
    public class TaskAssignment : BaseEntity
    {
        public Guid TaskId { get; set; }
        public Guid UserId { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Notes { get; set; }

        public virtual Task Task { get; set; }
        public virtual User User { get; set; }
    }
}
