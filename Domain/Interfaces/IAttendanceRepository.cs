using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IAttendanceRepository : IGenericRepository<Attendance>
    {
        Task<IEnumerable<Attendance>> GetByEmployeeIdAsync(Guid employeeId, DateTime? from = null, DateTime? to = null);
        Task<IEnumerable<Attendance>> GetByProjectIdAsync(Guid projectId, DateTime? date = null);
        Task<IEnumerable<Attendance>> GetUnconfirmedAttendancesAsync();
    }
}
