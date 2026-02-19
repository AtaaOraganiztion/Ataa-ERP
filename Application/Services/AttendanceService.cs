using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using SharedKernel.Results;

namespace Application.Services
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendanceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<AttendanceDto>> GetByIdAsync(Guid id)
        {
            var attendance = await _unitOfWork.Attendances.GetByIdAsync(id);
            if (attendance == null)
                return Result<AttendanceDto>.Failure($"Attendance with ID {id} not found");

            return Result<AttendanceDto>.Success(MapToDto(attendance));
        }

        public async Task<Result<IEnumerable<AttendanceDto>>> GetByEmployeeAsync(Guid employeeId, DateTime? from = null, DateTime? to = null)
        {
            var attendances = await _unitOfWork.Attendances.GetByEmployeeIdAsync(employeeId, from, to);
            var dtos = attendances.Select(MapToDto);
            return Result<IEnumerable<AttendanceDto>>.Success(dtos);
        }

        public async Task<Result<IEnumerable<AttendanceDto>>> GetByProjectAsync(Guid projectId, DateTime? date = null)
        {
            var attendances = await _unitOfWork.Attendances.GetByProjectIdAsync(projectId, date);
            var dtos = attendances.Select(MapToDto);
            return Result<IEnumerable<AttendanceDto>>.Success(dtos);
        }

        public async Task<Result<AttendanceDto>> CreateAsync(CreateAttendanceDto dto)
        {
            var attendance = new Attendance
            {
                EmployeeId = dto.EmployeeId,
                ProjectId = dto.ProjectId,
                Date = dto.Date,
                CheckInTime = dto.CheckInTime,
                CheckOutTime = dto.CheckOutTime,
                HoursWorked = dto.HoursWorked,
                HoursToWork = dto.HoursToWork,
                Status = dto.Status,
                IsConfirmed = false,
                Notes = dto.Notes
            };

            await _unitOfWork.Attendances.AddAsync(attendance);
            await _unitOfWork.SaveChangesAsync();

            return Result<AttendanceDto>.Success(MapToDto(attendance), "Attendance recorded successfully");
        }

        public async Task<Result<AttendanceDto>> ConfirmAsync(ConfirmAttendanceDto dto, Guid confirmedBy)
        {
            var attendance = await _unitOfWork.Attendances.GetByIdAsync(dto.AttendanceId);
            if (attendance == null)
                return Result<AttendanceDto>.Failure("Attendance not found");

            if (attendance.IsConfirmed)
                return Result<AttendanceDto>.Failure("Attendance already confirmed");

            attendance.IsConfirmed = dto.IsApproved;
            attendance.ConfirmedBy = confirmedBy;
            attendance.ConfirmedDate = DateTime.UtcNow;
            attendance.Notes = dto.Notes;

            await _unitOfWork.Attendances.UpdateAsync(attendance);
            await _unitOfWork.SaveChangesAsync();

            return Result<AttendanceDto>.Success(MapToDto(attendance), "Attendance confirmed successfully");
        }

        public async Task<Result<IEnumerable<AttendanceDto>>> GetUnconfirmedAsync()
        {
            var attendances = await _unitOfWork.Attendances.GetUnconfirmedAttendancesAsync();
            var dtos = attendances.Select(MapToDto);
            return Result<IEnumerable<AttendanceDto>>.Success(dtos);
        }

        private AttendanceDto MapToDto(Attendance attendance)
        {
            return new AttendanceDto
            {
                Id = attendance.Id,
                EmployeeId = attendance.EmployeeId,
                EmployeeName = attendance.Employee?.User?.Name,
                ProjectId = attendance.ProjectId,
                ProjectName = attendance.Project?.Name,
                Date = attendance.Date,
                CheckInTime = attendance.CheckInTime,
                CheckOutTime = attendance.CheckOutTime,
                HoursWorked = attendance.HoursWorked,
                HoursToWork = attendance.HoursToWork,
                Status = attendance.Status,
                IsConfirmed = attendance.IsConfirmed
            };
        }
    }
}
