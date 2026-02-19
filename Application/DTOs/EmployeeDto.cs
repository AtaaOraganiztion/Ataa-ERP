using System;
using Domain.Enums;

namespace Application.DTOs
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string EmployeeNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid SectorId { get; set; }
        public string SectorName { get; set; }
        public DateTime HireDate { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public string JobTitle { get; set; }
        public decimal BaseSalary { get; set; }
    }

    public class CreateEmployeeDto
    {
        public Guid UserId { get; set; }
        public string EmployeeNumber { get; set; }
        public Guid SectorId { get; set; }
        public DateTime HireDate { get; set; }
        public EmploymentType EmploymentType { get; set; }
        public string JobTitle { get; set; }
        public decimal BaseSalary { get; set; }
    }

    public class UpdateEmployeeDto
    {
        public Guid SectorId { get; set; }
        public string JobTitle { get; set; }
        public decimal BaseSalary { get; set; }
    }
}
