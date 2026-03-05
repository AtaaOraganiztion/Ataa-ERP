using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Entities.Enums;
using Domain.Enums;
using SharedKernel;
using SharedKernel.Common;
using Domain.Models;

namespace Domain.Models.Employee
{
    public class Employee : Entity,ISoftDeletableEntity
    {
        public string EmployeeFirstName { get; set; } = null!;
        public string EmployeeLastName { get; set; } = null!;
        public string EmployeeNumber { get; set; } = null!;
        public string EmployeeEmail { get; set; } = null!;
        public string JobTitle { get; set; } = null!;
        public Ulid? SectorId { get; set; }
        public DateTime HireDate { get; set; }
        public decimal BaseSalary { get; set; }
        public DateTime? TerminationDate { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public EmployeeStatus Status { get; set; }
        public string Location { get; set; } = null!;
        
        public virtual Sector Sector { get; set; }
        public virtual IEnumerable<Domain.Models.Salary.Salary> Salaries { get; set; }



        public bool IsDeleted { get; set; }
        public DateTime DeletedOnUtc { get; set; }
    }
}