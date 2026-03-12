using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Attendance.Dtos;
using Application.Features.Attendance.Specifications;
using AutoMapper;
using Domain.Models.Attendance;
using SharedKernel;

namespace Application.Features.Attendance.Queries.GetAll;

public class GetAttendanceQueryHandler(
    IRepository<Domain.Models.Attendance.Attendance> repository,
    IMapper mapper)
    : IQueryHandler<GetAttendanceQuery, List<AttendanceDto>>
{
    public async Task<Result<List<AttendanceDto>>> Handle(
        GetAttendanceQuery request,
        CancellationToken cancellationToken)
    {
        var attendances = await repository.ListAsync(
            new GetAttendanceSpec(request.Filter),
            cancellationToken);

        return Result.Success(mapper.Map<List<AttendanceDto>>(attendances));
    }
}
