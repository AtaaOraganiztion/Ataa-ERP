using Application.Abstractions.Messaging;
using Domain.Entities.Enums;
using Domain.Enums;
using System.Security.Cryptography;

namespace Application.Features.Finance.Expense.Commands.Add;

public record AddExpenseCommand(
     Ulid SectorId,
     Ulid? ProjectId ,
     decimal ExpenseAmount,
     int SectorNumber,
     decimal Amount,
     ExpenseType ExpenseType,
     DateTime ExpenseDate,
     string Description,
     string Category,
     ExpenseStatus Status,
     Ulid? RequestedBy ,
     Ulid? ApprovedBy ,
     DateTime? ApprovedDate ,
     string RejectionReason ,
     string ReceiptNumber ,
     bool IsConfirmed ,
     Ulid? ConfirmedBy ,
     DateTime? ConfirmedDate ,
     bool IsPaid ,
     DateTime? PaidDate ,
     decimal HoursWorked ,
     bool Confirm ,
     string? Notes 

    ) : ICommand<Ulid>;