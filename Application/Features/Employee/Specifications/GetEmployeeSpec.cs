
using Application.Features.Employee.Dtos;
using Application.Features.Employee.Dtos;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Employee.Specifications;

public class GetEmployeeSpec : Specification<Domain.Models.Employee.Employee>
{
    public GetEmployeeSpec(EmployeeFilter employeeFilter)
    {
        if (!string.IsNullOrWhiteSpace(employeeFilter.EmployeeFirstName))
        {
            Query.Where(x => x.EmployeeFirstName.Contains(employeeFilter.EmployeeFirstName));
        }
        
        if (!string.IsNullOrWhiteSpace(employeeFilter.EmployeeLastName))
        {
            Query.Where(x => x.EmployeeLastName.Contains(employeeFilter.EmployeeLastName));
        }
        
        if (!string.IsNullOrWhiteSpace(employeeFilter.EmployeeEmail))
        {
            Query.Where(x => x.EmployeeEmail.Contains(employeeFilter.EmployeeEmail));
        }
        
        if (!string.IsNullOrWhiteSpace(employeeFilter.JobTitle))
        {
            Query.Where(x => x.JobTitle.Contains(employeeFilter.JobTitle));
        }
        if (!string.IsNullOrWhiteSpace(employeeFilter.EmployeeNumber))
        {
            Query.Where(x => x.EmployeeNumber.Contains(employeeFilter.EmployeeNumber));
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
        if (employeeFilter.BaseSalary.HasValue)
        {
            Query.Where(t=>t.BaseSalary == employeeFilter.BaseSalary.Value);
        }
        
    }
}