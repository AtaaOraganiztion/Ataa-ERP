using System;
using System.Collections.Generic;
using Domain.Entities.Enums;
using Domain.Enums;
using Domain.Models.Adverisment;
using Domain.Models.Attendance;
using Microsoft.AspNetCore.Identity;

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
        public virtual ICollection<Attendance>? Attendances { get; set; }
        public virtual ICollection<Adverisment>? Adverisments { get; set; }
        public virtual ICollection<Domain.Models.Foras.Foras>? Foras { get; set; }
        public virtual ICollection<Domain.Models.CRM.Activity.Activity>? Activities { get; set; }
        public virtual ICollection<Domain.Models.CRM.GlobalActivity.GlobalActivity>? GlobalActivities { get; set; }

        // Navigation to Employee for the one-to-one relationship
        public virtual Domain.Models.Employee.Employee? Employee { get; set; }


        public User()
        {
            Status = UserStatus.Active;
            UserRoles = new HashSet<UserRole>();
            Activities = new HashSet<Domain.Models.CRM.Activity.Activity>();
            GlobalActivities = new HashSet<Domain.Models.CRM.GlobalActivity.GlobalActivity>();
        }
    }
}
