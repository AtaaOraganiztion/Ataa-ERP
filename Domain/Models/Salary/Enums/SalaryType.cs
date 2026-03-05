using System.ComponentModel;

namespace Domain.Entities.Enums;

public enum SalaryType
{
    [Description("دائم")]
    FullTime = 1,
    [Description("دوام جزئي")]
    PartTime = 2,
    [Description("عقد")]
    Contract = 3
}