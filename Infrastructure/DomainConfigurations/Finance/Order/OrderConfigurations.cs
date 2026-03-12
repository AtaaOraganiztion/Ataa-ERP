using Domain.Entities;
using Domain.Models.Finance.Order;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Infrastructure.DomainConfigurations.Finance.Order;

public class OrderConfigurations : IEntityTypeConfiguration<Domain.Models.Finance.Order.Order>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Finance.Order.Order> builder)
    {
        builder.ToTable("Order");

        builder
        .HasOne(o => o.Sector)
        .WithMany()
        .HasForeignKey(o => o.SectorId)
        .OnDelete(DeleteBehavior.Restrict);

        builder
        .Property(o => o.Price)
        .HasPrecision(18, 2);

    }
}