using System;

namespace Application.DTOs
{
    public class SalaryDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeNumber { get; set; }
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
        public bool IsPaid { get; set; }
    }

    public class CreateSalaryDto
    {
        public Guid EmployeeId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deductions { get; set; }
        public decimal OvertimeAmount { get; set; }
        public decimal BonusAmount { get; set; }
        public decimal HoursWorked { get; set; }
    }

    public class ProcessSalaryDto
    {
        public Guid EmployeeId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
