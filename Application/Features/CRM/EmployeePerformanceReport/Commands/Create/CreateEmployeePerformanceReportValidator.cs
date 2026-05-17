using FluentValidation;

namespace Application.Features.CRM.EmployeePerformanceReport.Commands.Create;

public class CreateEmployeePerformanceReportValidator : AbstractValidator<CreateEmployeePerformanceReportCommand>
{
    public CreateEmployeePerformanceReportValidator()
    {
        RuleFor(x => x.EmployeeName).NotEmpty().MaximumLength(200);
        RuleFor(x => x.ReportDate).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Associations).NotEmpty();
        RuleFor(x => x.Projects).NotEmpty();
    }
}
