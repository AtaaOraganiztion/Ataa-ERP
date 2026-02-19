using System.Collections.Generic;
using SharedKernel.Common;

namespace Domain.Entities
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Module { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }

        public Permission()
        {
            RolePermissions = new HashSet<RolePermission>();
        }
    }
}
