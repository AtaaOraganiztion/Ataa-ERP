using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using SharedKernel.Results;

namespace Application.Interfaces
{
    public interface ILeaveService
    {
        Task<Result<LeaveDto>> GetByIdAsync(Guid id);
        Task<Result<IEnumerable<LeaveDto>>> GetByEmployeeAsync(Guid employeeId);
        Task<Result<IEnumerable<LeaveDto>>> GetPendingLeavesAsync();
        Task<Result<LeaveDto>> CreateAsync(CreateLeaveDto dto);
        Task<Result<LeaveDto>> ApproveAsync(ApproveLeaveDto dto, Guid approvedBy);
    }
}
