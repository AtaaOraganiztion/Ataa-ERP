using Application.Features.Finance.Expense.Dtos;
using Ardalis.Specification;

namespace Application.Features.Finance.Expense.Specifications;

public class GetExpenseSpec : Specification<Domain.Models.Finance.Expense.Expense>
{
    public GetExpenseSpec(ExpenseFilter filter)
    {
        Query.Include(x => x.Sector);
        Query.Include(x => x.Project);
        Query.Include(x => x.Requester);
        Query.Include(x => x.Approver);
        Query.Include(x => x.Confirmer);

        if (filter.SectorId != default)
            Query.Where(x => x.SectorId == filter.SectorId);

        if (filter.ProjectId.HasValue)
            Query.Where(x => x.ProjectId == filter.ProjectId.Value);

        if (filter.ExpenseAmount != default)
            Query.Where(x => x.ExpenseAmount == filter.ExpenseAmount);

        if (filter.SectorNumber != default)
            Query.Where(x => x.SectorNumber == filter.SectorNumber);

        if (filter.Amount != default)
            Query.Where(x => x.Amount == filter.Amount);

        if (filter.ExpenseType != default)
            Query.Where(x => x.ExpenseType == filter.ExpenseType);

        if (filter.ExpenseDate != default)
            Query.Where(x => x.ExpenseDate.Date == filter.ExpenseDate.Date);

        if (!string.IsNullOrWhiteSpace(filter.Description))
            Query.Where(x => x.Description.Contains(filter.Description));

        if (!string.IsNullOrWhiteSpace(filter.Category))
            Query.Where(x => x.Category.Contains(filter.Category));

        if (filter.Status != default)
            Query.Where(x => x.Status == filter.Status);

        if (filter.RequestedBy.HasValue)
            Query.Where(x => x.RequestedBy == filter.RequestedBy.Value);

        if (filter.ApprovedBy.HasValue)
            Query.Where(x => x.ApprovedBy == filter.ApprovedBy.Value);

        if (filter.ApprovedDate.HasValue)
            Query.Where(x => x.ApprovedDate.HasValue &&
                             x.ApprovedDate.Value.Date == filter.ApprovedDate.Value.Date);

        if (!string.IsNullOrWhiteSpace(filter.RejectionReason))
            Query.Where(x => x.RejectionReason.Contains(filter.RejectionReason));

        if (!string.IsNullOrWhiteSpace(filter.ReceiptNumber))
            Query.Where(x => x.ReceiptNumber.Contains(filter.ReceiptNumber));

        if (filter.IsConfirmed != default)
            Query.Where(x => x.IsConfirmed == filter.IsConfirmed);

        if (filter.ConfirmedBy.HasValue)
            Query.Where(x => x.ConfirmedBy == filter.ConfirmedBy.Value);

        if (filter.ConfirmedDate.HasValue)
            Query.Where(x => x.ConfirmedDate.HasValue &&
                             x.ConfirmedDate.Value.Date == filter.ConfirmedDate.Value.Date);

        if (filter.IsPaid != default)
            Query.Where(x => x.IsPaid == filter.IsPaid);

        if (filter.PaidDate.HasValue)
            Query.Where(x => x.PaidDate.HasValue &&
                             x.PaidDate.Value.Date == filter.PaidDate.Value.Date);

        if (filter.HoursWorked != default)
            Query.Where(x => x.HoursWorked == filter.HoursWorked);

        if (filter.Confirm != default)
            Query.Where(x => x.Confirm == filter.Confirm);

        if (!string.IsNullOrWhiteSpace(filter.Notes))
            Query.Where(x => x.Notes.Contains(filter.Notes));
    }
}