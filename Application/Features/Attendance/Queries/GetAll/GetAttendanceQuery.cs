using Application.Abstractions.Messaging;
using Application.Features.Attendance.Dtos;

namespace Application.Features.Attendance.Queries.GetAll;

public record GetAttendanceQuery(AttendanceFilter Filter) : IQuery<List<AttendanceDto>>;
