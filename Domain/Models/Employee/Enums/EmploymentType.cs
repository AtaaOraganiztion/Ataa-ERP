using System.ComponentModel;

namespace Domain.Entities.Enums;

public enum EmploymentType
{
    [Description("دائم")]
    FullTime,
    [Description("دوام جزئي")]
    PartTime,
    [Description("عقد")]
    Contract
}