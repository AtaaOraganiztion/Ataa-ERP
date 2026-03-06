using Application.Features.Attendance.Dtos;
using AutoMapper;
using Domain.Models.Attendance;

namespace Application.Mapping.Attendance;

public class AttendanceProfile : Profile
{
    public AttendanceProfile()
    {
        CreateMap<Domain.Models.Attendance.Attendance, AttendanceDto>()
            .ForMember(dest => dest.EmployeeFullName,
                opt => opt.MapFrom(src =>
                    src.Employee != null
                        ? $"{src.Employee.EmployeeFirstName} {src.Employee.EmployeeLastName}"
                        : string.Empty))
            .ForMember(dest => dest.SectorId,
                opt => opt.MapFrom(src =>
                    src.Employee != null ? src.Employee.SectorId : null))
            .ForMember(dest => dest.SectorName,
                opt => opt.MapFrom(src =>
                    src.Employee != null && src.Employee.Sector != null
                        ? src.Employee.Sector.Name
                        : null));
    }
}
