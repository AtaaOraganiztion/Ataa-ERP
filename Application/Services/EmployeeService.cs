using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using SharedKernel.Exceptions;
using SharedKernel.Results;

namespace Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<EmployeeDto>> GetByIdAsync(Guid id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee == null)
                return Result<EmployeeDto>.Failure($"Employee with ID {id} not found");

            return Result<EmployeeDto>.Success(MapToDto(employee));
        }

        public async Task<Result<IEnumerable<EmployeeDto>>> GetAllAsync()
        {
            var employees = await _unitOfWork.Employees.GetAllAsync();
            var dtos = employees.Select(MapToDto);
            return Result<IEnumerable<EmployeeDto>>.Success(dtos);
        }

        public async Task<Result<IEnumerable<EmployeeDto>>> GetBySectorAsync(Guid sectorId)
        {
            var employees = await _unitOfWork.Employees.GetBySectorIdAsync(sectorId);
            var dtos = employees.Select(MapToDto);
            return Result<IEnumerable<EmployeeDto>>.Success(dtos);
        }

        public async Task<Result<EmployeeDto>> CreateAsync(CreateEmployeeDto dto)
        {
            // Validate user exists
            var user = await _unitOfWork.Users.GetByIdAsync(dto.UserId);
            if (user == null)
                return Result<EmployeeDto>.Failure("User not found");

            // Check if employee already exists for this user
            var existingEmployee = await _unitOfWork.Employees.GetByUserIdAsync(dto.UserId);
            if (existingEmployee != null)
                return Result<EmployeeDto>.Failure("Employee record already exists for this user");

            var employee = new Employee
            {
                UserId = dto.UserId,
                EmployeeNumber = dto.EmployeeNumber,
                SectorId = dto.SectorId,
                HireDate = dto.HireDate,
                EmploymentType = dto.EmploymentType,
                JobTitle = dto.JobTitle,
                BaseSalary = dto.BaseSalary
            };

            await _unitOfWork.Employees.AddAsync(employee);
            await _unitOfWork.SaveChangesAsync();

            return Result<EmployeeDto>.Success(MapToDto(employee), "Employee created successfully");
        }

        public async Task<Result<EmployeeDto>> UpdateAsync(Guid id, UpdateEmployeeDto dto)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee == null)
                return Result<EmployeeDto>.Failure($"Employee with ID {id} not found");

            employee.SectorId = dto.SectorId;
            employee.JobTitle = dto.JobTitle;
            employee.BaseSalary = dto.BaseSalary;

            await _unitOfWork.Employees.UpdateAsync(employee);
            await _unitOfWork.SaveChangesAsync();

            return Result<EmployeeDto>.Success(MapToDto(employee), "Employee updated successfully");
        }

        public async Task<Result> DeleteAsync(Guid id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            if (employee == null)
                return Result.Failure($"Employee with ID {id} not found");

            await _unitOfWork.Employees.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Employee deleted successfully");
        }

        private EmployeeDto MapToDto(Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                EmployeeNumber = employee.EmployeeNumber,
                Name = employee.User?.Name,
                Email = employee.User?.Email,
                SectorId = employee.SectorId,
                SectorName = employee.Sector?.Name,
                HireDate = employee.HireDate,
                EmploymentType = employee.EmploymentType,
                JobTitle = employee.JobTitle,
                BaseSalary = employee.BaseSalary
            };
        }
    }
}
