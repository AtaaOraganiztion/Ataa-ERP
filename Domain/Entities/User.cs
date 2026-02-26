using System;
using System.Collections.Generic;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using SharedKernel.Common;

namespace Domain.Entities
{
    public class User : IdentityUser<Ulid>
    {
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? NID { get; set; }
        public int? Age { get; set; }
        public Gender? Gender { get; set; }
        public UserStatus Status { get; set; }
        public DateTime? LastLoginDate { get; set; }

        // Navigation Properties
        public virtual ICollection<UserRole> UserRoles { get; set; }


        public User()
        {
            Status = UserStatus.Active;
            UserRoles = new HashSet<UserRole>();
        }
    }
}
