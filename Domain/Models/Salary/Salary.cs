using System;
using Domain.Entities;
using SharedKernel;
using SharedKernel.Common;

namespace Domain.Models.Salary
{
    public class Salary : Entity,ISoftDeletableEntity
    {
        public Ulid EmployeeId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deductions { get; set; }
        public decimal OvertimeAmount { get; set; }
        public decimal BonusAmount { get; set; }
        public decimal NetSalary { get; set; }
        public decimal HoursWorked { get; set; }
        public bool IsConfirmed { get; set; }
        public Ulid? ConfirmedBy { get; set; }
        public DateTime? ConfirmedDate { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }

        public virtual Employee.Employee Employee { get; set; }
        public virtual User Confirmer { get; set; }
        
        public bool IsDeleted { get; set; }
        public DateTime DeletedOnUtc { get; set; }
    }
}