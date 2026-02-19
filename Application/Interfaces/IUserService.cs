using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTOs;
using SharedKernel.Results;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<Result<UserDto>> GetByIdAsync(Guid id);
        Task<Result<IEnumerable<UserDto>>> GetAllAsync();
        Task<Result<UserDto>> CreateAsync(CreateUserDto dto);
        Task<Result<UserDto>> UpdateAsync(Guid id, UpdateUserDto dto);
        Task<Result> DeleteAsync(Guid id);
        Task<Result<UserDto>> GetByEmailAsync(string email);
    }
}
