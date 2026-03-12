using Domain.Entities;
using Domain.Models.Finance.Budget;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.DomainConfigurations.Finance.Expense;

public class BudgetConfigurations : IEntityTypeConfiguration<Domain.Models.Finance.Expense.Expense>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Finance.Expense.Expense> builder)
    {
        builder.ToTable("Expense");

        builder
            .HasOne(e => e.Sector)
            .WithMany()
            .HasForeignKey(e => e.SectorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(e => e.Project)
            .WithMany(p => p.Expenses)
            .HasForeignKey(e => e.ProjectId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(e => e.Requester)
            .WithMany()
            .HasForeignKey(e => e.RequestedBy)
            .OnDelete(DeleteBehavior.Restrict);

        builder
             .HasOne(e => e.Approver)
            .WithMany()
            .HasForeignKey(e => e.ApprovedBy)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(e => e.Confirmer)
            .WithMany()
            .HasForeignKey(e => e.ConfirmedBy)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .Property(e => e.Amount)
            .HasPrecision(18, 2);

        builder
             .Property(e => e.ExpenseAmount)
            .HasPrecision(18, 2);

        builder
            .Property(e => e.HoursWorked)
            .HasPrecision(18, 2);

    }
}