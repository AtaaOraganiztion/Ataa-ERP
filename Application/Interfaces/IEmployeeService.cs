using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using SharedKernel.Results;

namespace Application.Interfaces
{
    public interface IEmployeeService
    {
        Task<Result<EmployeeDto>> GetByIdAsync(Guid id);
        Task<Result<IEnumerable<EmployeeDto>>> GetAllAsync();
        Task<Result<IEnumerable<EmployeeDto>>> GetBySectorAsync(Guid sectorId);
        Task<Result<EmployeeDto>> CreateAsync(CreateEmployeeDto dto);
        Task<Result<EmployeeDto>> UpdateAsync(Guid id, UpdateEmployeeDto dto);
        Task<Result> DeleteAsync(Guid id);
    }
}
