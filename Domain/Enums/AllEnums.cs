namespace Domain.Enums
{
    public enum LeaveType { Annual = 1, Sick = 2, Unpaid = 3, Maternity = 4, Paternity = 5 }
    public enum LeaveStatus { Pending = 1, Approved = 2, Rejected = 3, Cancelled = 4 }
    public enum ProjectStatus { Planning = 1, InProgress = 2, OnHold = 3, Completed = 4, Cancelled = 5 }
    public enum TaskStatus { NotStarted = 1, Assigned = 2, InProgress = 3, Pending = 4, Completed = 5 }
    public enum TaskPriority { Low = 1, Medium = 2, High = 3, Critical = 4 }
    public enum ExpenseType { Employee = 1, Purchase = 2, Supplies = 3, Service = 4, Equipment = 5 }
    public enum ExpenseStatus { Draft = 1, Pending = 2, Approved = 3, Rejected = 4, Paid = 5 }
    public enum BudgetStatus { Draft = 1, Submitted = 2, Approved = 3, Active = 4, Exceeded = 5 }
    public enum PaymentStatus { Pending = 1, Approved = 2, Processing = 3, Paid = 4, Failed = 5 }
    public enum ContractType { FixedPrice = 1, TimeAndMaterial = 2, Retainer = 3 }
    public enum ContractStatus { Draft = 1, Active = 2, Suspended = 3, Completed = 4, Terminated = 5 }
    public enum Gender { Male = 1, Female = 2, Other = 3 }
    public enum ApprovalStatus { Pending = 1, Approved = 2, Rejected = 3 }
}
