using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context) { }

        public async Task<Employee> GetByEmployeeNumberAsync(string employeeNumber)
        {
            return await _dbSet
                .Include(e => e.User)
                .Include(e => e.Sector)
                .FirstOrDefaultAsync(e => e.EmployeeNumber == employeeNumber);
        }

        public async Task<IEnumerable<Employee>> GetBySectorIdAsync(Guid sectorId)
        {
            return await _dbSet
                .Include(e => e.User)
                .Include(e => e.Sector)
                .Where(e => e.SectorId == sectorId)
                .ToListAsync();
        }

        public async Task<Employee> GetByUserIdAsync(Guid userId)
        {
            return await _dbSet
                .Include(e => e.User)
                .Include(e => e.Sector)
                .FirstOrDefaultAsync(e => e.UserId == userId);
        }
    }
}
