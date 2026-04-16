using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class LeadConfiguration : IEntityTypeConfiguration<Domain.Models.CRM.Lead.Lead>
{
    public void Configure(EntityTypeBuilder<Domain.Models.CRM.Lead.Lead> builder)
    {
        builder.ToTable("Lead");
        builder.HasIndex(l => l.Status);
        builder.HasIndex(l => l.IsDeleted);

        builder.Property(l => l.Title).IsRequired().HasMaxLength(200);
        builder.Property(l => l.Value).HasPrecision(18, 2);

        builder.HasOne(l => l.Customer)
            .WithMany(c => c.Leads)
            .HasForeignKey(l => l.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(l => l.AssignedTo)
            .WithMany()
            .HasForeignKey(l => l.AssignedToUserId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}