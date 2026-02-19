using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ISalaryRepository : IGenericRepository<Salary>
    {
        Task<IEnumerable<Salary>> GetByEmployeeIdAsync(Guid employeeId, int? year = null);
        Task<Salary> GetByEmployeeAndMonthAsync(Guid employeeId, int month, int year);
        Task<IEnumerable<Salary>> GetUnpaidSalariesAsync();
    }
}
