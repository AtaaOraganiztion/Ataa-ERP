
using Domain.Entities.Enums;
using Domain.Enums;

namespace Application.Features.Finance.Expense.Dtos;

public record UpdateExpenseDto(
     Ulid SectorId,
     Ulid? ProjectId,
     decimal ExpenseAmount,
     int SectorNumber,
     decimal Amount,
     ExpenseType ExpenseType,
     DateTime ExpenseDate,
     string Description,
     string Category,
     ExpenseStatus Status,
     Ulid? RequestedBy,
     Ulid? ApprovedBy,
     DateTime? ApprovedDate,
     string RejectionReason,
     string ReceiptNumber,
     bool IsConfirmed,
     Ulid? ConfirmedBy,
     DateTime? ConfirmedDate,
     bool IsPaid,
     DateTime? PaidDate,
     decimal HoursWorked,
     bool Confirm,
     string? Notes
    );