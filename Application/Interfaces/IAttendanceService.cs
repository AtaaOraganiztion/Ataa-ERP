using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using SharedKernel.Results;

namespace Application.Interfaces
{
    public interface IAttendanceService
    {
        Task<Result<AttendanceDto>> GetByIdAsync(Guid id);
        Task<Result<IEnumerable<AttendanceDto>>> GetByEmployeeAsync(Guid employeeId, DateTime? from = null, DateTime? to = null);
        Task<Result<IEnumerable<AttendanceDto>>> GetByProjectAsync(Guid projectId, DateTime? date = null);
        Task<Result<AttendanceDto>> CreateAsync(CreateAttendanceDto dto);
        Task<Result<AttendanceDto>> ConfirmAsync(ConfirmAttendanceDto dto, Guid confirmedBy);
        Task<Result<IEnumerable<AttendanceDto>>> GetUnconfirmedAsync();
    }
}
