using Application.Features.Salary.Dtos;
using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Salary.Specifications;

public class GetSalarySpec : Specification<Domain.Models.Salary.Salary>
{
    public GetSalarySpec(SalaryFilter salaryFilter)
    {

        if(salaryFilter.NetSalary.HasValue)
        {
            Query.Where(t=>t.NetSalary==salaryFilter.NetSalary.Value);
        }
        if(salaryFilter.Allowances.HasValue)
        {
            Query.Where(t=>t.Allowances==salaryFilter.Allowances.Value);
        }
        if (salaryFilter.Deductions.HasValue)
        {
            Query.Where(t => t.Deductions == salaryFilter.Deductions.Value);
        }
        if (salaryFilter.HoursWorked.HasValue) 
        {
            Query.Where(t=>t.HoursWorked == salaryFilter.HoursWorked.Value);
        }

        if (salaryFilter.OvertimeAmount.HasValue)
        {
            Query.Where(t => t.OvertimeAmount == salaryFilter.OvertimeAmount.Value);
        }

        if (salaryFilter.IsConfirmed.HasValue)
        {
            Query.Where(t => t.IsConfirmed == salaryFilter.IsConfirmed.Value);
        }
        if (salaryFilter.BaseSalary.HasValue)
        {
            Query.Where(t => t.BaseSalary == salaryFilter.BaseSalary.Value);
        }

        if (salaryFilter.Month.HasValue) 
        {
            Query.Where(t=>t.Month == salaryFilter.Month.Value);
        }
        if (salaryFilter.Year.HasValue)
        {
            Query.Where(t => t.Year == salaryFilter.Year.Value);
        }
        


    }
}