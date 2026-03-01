using System.ComponentModel;

namespace Domain.Entities.Enums;

public enum EmployeeStatus
{
    [Description("نشط")]
    Active = 1,
    [Description("غير نشط")]
    Inactive = 2
}