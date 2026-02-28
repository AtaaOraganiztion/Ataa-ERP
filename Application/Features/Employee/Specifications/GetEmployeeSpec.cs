
using Application.Features.Employee.Dtos;
using Application.Features.Employee.Dtos;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Employee.Specifications;

public class GetEmployeeSpec : Specification<Domain.Models.Employee.Employee>
{
    public GetEmployeeSpec(EmployeeFilter employeeFilter)
    {
        if (!string.IsNullOrWhiteSpace(employeeFilter.FirstName))
        {
            Query.Where(x => x.EmployeeFirstName.Contains(employeeFilter.FirstName));
        }
        
        if (!string.IsNullOrWhiteSpace(employeeFilter.LastName))
        {
            Query.Where(x => x.EmployeeLastName.Contains(employeeFilter.LastName));
        }
        
        if (!string.IsNullOrWhiteSpace(employeeFilter.Email))
        {
            Query.Where(x => x.EmployeeEmail.Contains(employeeFilter.Email));
        }
        
        if (!string.IsNullOrWhiteSpace(employeeFilter.jobTitle))
        {
            Query.Where(x => x.JobTitle.Contains(employeeFilter.jobTitle));
        }
        if (!string.IsNullOrWhiteSpace(employeeFilter.Phone))
        {
            Query.Where(x => x.EmployeeNumber.Contains(employeeFilter.Phone));
        }
        
        if (employeeFilter.SectorId is { } sectorId && sectorId != default)
        {
            Query.Where(x => x.SectorId == sectorId);
        }
        
        if (employeeFilter.EmploymentType.HasValue)
        {
            Query.Where(t=>t.EmploymentType == employeeFilter.EmploymentType.Value);
        }
        
        if (employeeFilter.Status.HasValue)
        {
            Query.Where(t=>t.Status == employeeFilter.Status.Value);
        }
        if (employeeFilter.Salary.HasValue)
        {
            Query.Where(t=>t.BaseSalary == employeeFilter.Salary.Value);
        }
        
    }
}