using System;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class UserRole : IdentityUserRole<Ulid>
    {
        public Ulid UserId { get; set; }
        public Ulid RoleId { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
