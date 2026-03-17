using Domain.Entities;
using Domain.Models.Finance.Budget;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DomainConfigurations.Finance.Budget;

public class BudgetAllocationsConfigurations : IEntityTypeConfiguration<BudgetAllocation>
{
    public void Configure(EntityTypeBuilder<BudgetAllocation> builder)
    {
        builder.ToTable("BudgetAllocation");
        builder
            .HasIndex(b => b.AllocatedAmount);
        builder
            .HasIndex(b => b.Category)
            .IsUnique();
        builder
            .HasIndex(b => b.BudgetId)
            .IsUnique();
        builder
            .HasIndex(b => b.SpentAmount);
        builder
            .HasIndex(b => b.Description);

        builder
         .HasOne(ba => ba.Budget)
        .WithMany(b => b.BudgetAllocations)
        .HasForeignKey(ba => ba.BudgetId)
        .OnDelete(DeleteBehavior.Cascade);

        builder
         .Property(ba => ba.AllocatedAmount)
        .HasPrecision(18, 2);

        builder
       .Property(ba => ba.SpentAmount)
        .HasPrecision(18, 2);
    }
}