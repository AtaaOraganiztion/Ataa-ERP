using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee> GetByEmployeeNumberAsync(string employeeNumber);
        Task<IEnumerable<Employee>> GetBySectorIdAsync(Guid sectorId);
        Task<Employee> GetByUserIdAsync(Guid userId);
    }
}
