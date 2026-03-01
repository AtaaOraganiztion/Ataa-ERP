using System;
using SharedKernel.Common;

namespace Domain.Entities
{
    public class RolePermission : BaseEntity
    {
        public Ulid RoleId { get; set; }
        public Ulid PermissionId { get; set; }

        public virtual Role Role { get; set; }
    }
}
