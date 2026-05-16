using FluentValidation;

namespace Application.Features.CRM.EmployeePerformanceReport.Commands.Update;

public class UpdateEmployeePerformanceReportValidator : AbstractValidator<UpdateEmployeePerformanceReportCommand>
{
    public UpdateEmployeePerformanceReportValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Request.EmployeeName).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Request.ReportDate).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Request.Associations).NotEmpty();
        RuleFor(x => x.Request.Projects).NotEmpty();
    }
}
