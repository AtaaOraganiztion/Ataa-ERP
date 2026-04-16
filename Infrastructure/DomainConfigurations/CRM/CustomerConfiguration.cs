using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Enums.CRM;

namespace Infrastructure.DomainConfigurations.CRM;

public class CustomerConfiguration : IEntityTypeConfiguration<Domain.Models.CRM.Customer.Customer>
{
    public void Configure(EntityTypeBuilder<Domain.Models.CRM.Customer.Customer> builder)
    {
        builder.ToTable("Customer");
        builder.HasIndex(c => c.Email);
        builder.HasIndex(c => c.Status);
        builder.HasIndex(c => c.IsDeleted);

        builder.Property(c => c.FullName).IsRequired().HasMaxLength(200);
        builder.Property(c => c.Email).HasMaxLength(200);
        builder.Property(c => c.Phone).HasMaxLength(50);
        builder.Property(c => c.Company).HasMaxLength(200);

        builder.HasOne(c => c.AssignedTo)
            .WithMany()
            .HasForeignKey(c => c.AssignedToUserId)
            .OnDelete(DeleteBehavior.SetNull);


        builder.HasMany(c=>c.Deals)
            .WithOne(c => c.Customer)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
