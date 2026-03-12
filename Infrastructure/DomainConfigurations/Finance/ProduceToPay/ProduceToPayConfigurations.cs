using Domain.Entities;
using Domain.Models.Finance.ProcureToPay;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.DomainConfigurations.Finance.ProduceToPay;

public class ProduceToPayConfigurations : IEntityTypeConfiguration<Domain.Models.Finance.ProcureToPay.ProcureToPay>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Finance.ProcureToPay.ProcureToPay> builder)
    {
        builder.ToTable("ProcureToPay");

        builder
            .HasOne(p => p.Sector)
            .WithMany()
            .HasForeignKey(p => p.SectorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
             .Property(p => p.ProcureAmount)
            .HasPrecision(18, 2);

        builder
             .Property(p => p.UpdateBudget)
            .HasPrecision(18, 2);
    }
}