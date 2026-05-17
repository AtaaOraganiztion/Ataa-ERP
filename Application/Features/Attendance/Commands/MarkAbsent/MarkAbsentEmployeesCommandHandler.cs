using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.Features.Attendance.Specifications;
using Domain.Entities;
using Domain.Models.Attendance.Enums;
using SharedKernel;


namespace Application.Features.Attendance.Commands.MarkAbsent;

public class MarkAbsentEmployeesCommandHandler(
    IReadRepository<Domain.Entities.User> userRepository,
    IRepository<Domain.Models.Attendance.Attendance> attendanceRepository)
    : ICommandHandler<MarkAbsentEmployeesCommand>
{
    public async Task<Result> Handle(MarkAbsentEmployeesCommand request, CancellationToken cancellationToken)
    {
        // AST is UTC+3
        var todayAst = DateTime.UtcNow.AddHours(3).Date;

        // 1. Get all active users using Specification
        var activeUsers = await userRepository.ListAsync(
            new ActiveUsersSpec(),
            cancellationToken);

        // 2. Get today's attendance records using Specification
        var todaysAttendances = await attendanceRepository.ListAsync(
            new AttendanceByDateSpec(todayAst),
            cancellationToken);

        var userIdsWithAttendance = todaysAttendances
            .Where(a => a.UserId.HasValue)
            .Select(a => a.UserId!.Value)
            .ToHashSet();

        // 3. Mark absent for those who don't have a record
        var absentAttendances = new List<Domain.Models.Attendance.Attendance>();

        foreach (var user in activeUsers)
        {
            if (!userIdsWithAttendance.Contains(user.Id))
            {
                absentAttendances.Add(new Domain.Models.Attendance.Attendance
                {
                    Id = Ulid.NewUlid(),
                    UserId = user.Id,
                    Date = todayAst,
                    Status = AttendanceStatus.Absent,
                    IsConfirmed = false,
                    IsDeleted = false,
                    Notes = "تم التسجيل غياب تلقائي بعد الساعة 9 صباحاً"
                });
            }
        }

        if (absentAttendances.Any())
        {
            await attendanceRepository.AddRangeAsync(absentAttendances, cancellationToken);
        }

        return Result.Success();
    }
}
