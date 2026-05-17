using Application.Features.Attendance.Commands.MarkAbsent;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infrastructure.BackgroundTasks;

public class AttendanceBackgroundService(
    IServiceScopeFactory scopeFactory,
    ILogger<AttendanceBackgroundService> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("Attendance Background Service is starting.");

        while (!stoppingToken.IsCancellationRequested)
        {
            var nowAst = DateTime.UtcNow.AddHours(3);
            
            // Run exactly at 9 AM AST or the first time after 9 AM
            if (nowAst.Hour >= 9)
            {
                logger.LogInformation("Checking for absent employees at {Time} AST", nowAst);
                
                using (var scope = scopeFactory.CreateScope())
                {
                    var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                    
                    try 
                    {
                        await mediator.Send(new MarkAbsentEmployeesCommand(), stoppingToken);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "Error occurred while marking absent employees.");
                    }
                }

                // After running, sleep until the next day at 8 AM AST to avoid re-running every minute
                var nextRun = nowAst.Date.AddDays(1).AddHours(8);
                var delay = nextRun - nowAst;
                logger.LogInformation("Job finished for today. Sleeping for {Delay} until {NextRun} AST", delay, nextRun);
                await Task.Delay(delay, stoppingToken);
            }
            else
            {
                // If it's before 9 AM, check again in 1 minute
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}
