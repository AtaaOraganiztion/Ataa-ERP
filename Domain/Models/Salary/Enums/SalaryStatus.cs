using System.ComponentModel;

namespace Domain.Entities.Enums;

public enum SalaryStatus
{
    [Description("نشط")]
    Active = 1,
    [Description("غير نشط")]
    Inactive = 2
}