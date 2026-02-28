using System.ComponentModel;

namespace Domain.Entities.Enums;

public enum EmployeeStatus
{
    [Description("نشط")]
    Active,
    [Description("غير نشط")]
    Inactive
}