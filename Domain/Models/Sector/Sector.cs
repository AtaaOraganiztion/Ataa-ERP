using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Models.Employee;
using SharedKernel;
namespace Domain.Models.Sector
{
    public class Sector : Entity,ISoftDeletableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Ulid? ParentSectorId { get; set; }
        public Ulid? ManagerUserId { get; set; }

        public virtual Sector? ParentSector { get; set; }
        public virtual User? Manager { get; set; }
        public virtual ICollection<Sector> ChildSectors { get; set; }
        public virtual ICollection<Employee.Employee> Employees { get; set; }

        public Sector()
        {
            ChildSectors = new HashSet<Sector>();
            Employees = new HashSet<Employee.Employee>();
        }

        public bool IsDeleted { get; set; }
        public DateTime DeletedOnUtc { get; set; }
    }
}