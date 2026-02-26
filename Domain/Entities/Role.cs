using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using SharedKernel.Common;

namespace Domain.Entities
{
    public class Role : IdentityRole<Ulid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsSystemRole { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }

        public Role()
        {
            UserRoles = new HashSet<UserRole>();
            RolePermissions = new HashSet<RolePermission>();
        }
    }
}
