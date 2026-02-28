using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Models.Employee;
using SharedKernel.Common;

namespace Domain.Models
{
    public class Sector : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? ParentSectorId { get; set; }
        public Guid? ManagerUserId { get; set; }

        public virtual Sector ParentSector { get; set; }
        public virtual User Manager { get; set; }
        public virtual ICollection<Sector> ChildSectors { get; set; }
        public virtual ICollection<Employee.Employee> Employees { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }

        public Sector()
        {
            ChildSectors = new HashSet<Sector>();
            Employees = new HashSet<Employee.Employee>();
            Budgets = new HashSet<Budget>();
        }
    }
}