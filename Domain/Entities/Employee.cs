using System;
using System.Collections.Generic;
using Domain.Enums;
using SharedKernel.Common;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public Guid UserId { get; set; }
        public string EmployeeNumber { get; set; }
        public Guid SectorId { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public string JobTitle { get; set; }
        public decimal BaseSalary { get; set; }

        public virtual User User { get; set; }
        public virtual Sector Sector { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Leave> Leaves { get; set; }
        public virtual ICollection<Salary> Salaries { get; set; }
        public virtual ICollection<KPI> KPIs { get; set; }

        public Employee()
        {
            Attendances = new HashSet<Attendance>();
            Leaves = new HashSet<Leave>();
            Salaries = new HashSet<Salary>();
            KPIs = new HashSet<KPI>();
        }
    }
}
