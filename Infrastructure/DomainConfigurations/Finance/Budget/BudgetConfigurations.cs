using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Finance.Budget;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DomainConfigurations.Finance.Budget;

public class BudgetConfigurations : IEntityTypeConfiguration<Domain.Models.Finance.Budget.Budget>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Finance.Budget.Budget> builder)
    {
        builder.ToTable("Budget");
        builder
            .HasIndex(b => b.CreatedBy);
        builder
            .HasIndex(b => b.IsDeleted)
            .IsUnique();
        builder
            .HasIndex(b => b.SectorId)
            .IsUnique();
        builder
            .HasIndex(b => b.Status);

        builder
        .HasOne(b => b.Sector)
        .WithMany()
        .HasForeignKey(b => b.SectorId)
        .OnDelete(DeleteBehavior.Restrict);


        builder
        .HasOne(b => b.Confirmer)
        .WithMany()
        .HasForeignKey(b => b.ConfirmedBy)
        .OnDelete(DeleteBehavior.Restrict);
        
        builder
        .Property(b => b.TotalBudget)
        .HasPrecision(18, 2);

        builder
          .Property(b => b.EstimatedBudget)
          .HasPrecision(18, 2);

        builder
         .Property(b => b.AllocatedAmount)
        .HasPrecision(18, 2);

        builder
        .Property(ba => ba.SpentAmount)
        .HasPrecision(18, 2);

        builder
         .Property(ba => ba.AllocatedAmount)
        .HasPrecision(18, 2);

     
    }
}