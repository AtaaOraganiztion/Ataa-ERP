using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using SharedKernel.Results;

namespace Application.Interfaces
{
    public interface ISalaryService
    {
        Task<Result<SalaryDto>> GetByIdAsync(Guid id);
        Task<Result<IEnumerable<SalaryDto>>> GetByEmployeeAsync(Guid employeeId, int? year = null);
        Task<Result<SalaryDto>> ProcessSalaryAsync(ProcessSalaryDto dto);
        Task<Result<SalaryDto>> ConfirmSalaryAsync(Guid salaryId, Guid confirmedBy);
        Task<Result<IEnumerable<SalaryDto>>> GetUnpaidSalariesAsync();
        Task<Result> MarkAsPaidAsync(Guid salaryId);
    }
}
