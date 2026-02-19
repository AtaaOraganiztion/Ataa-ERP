using System;
using System.Collections.Generic;
using Domain.Enums;
using SharedKernel.Common;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string NID { get; set; }
        public int? Age { get; set; }
        public Gender? Gender { get; set; }
        public UserStatus Status { get; set; }
        public string PasswordHash { get; set; }
        public DateTime? LastLoginDate { get; set; }

        // Navigation Properties
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<TaskAssignment> TaskAssignments { get; set; }
        public virtual ICollection<ProjectTeam> ProjectTeams { get; set; }

        public User()
        {
            Status = UserStatus.Active;
            UserRoles = new HashSet<UserRole>();
        }
    }
}
