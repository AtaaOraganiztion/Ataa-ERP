using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models.CRM.GlobalActivity;

namespace Infrastructure.DomainConfigurations.CRM;

public class GlobalActivityConfiguration : IEntityTypeConfiguration<GlobalActivity>
{
    public void Configure(EntityTypeBuilder<GlobalActivity> builder)
    {
        builder.ToTable("GlobalActivities");
        builder.HasKey(a => a.Id);
        
        builder.HasIndex(a => a.Type);
        builder.HasIndex(a => a.IsDeleted);

        builder.Property(a => a.Subject).IsRequired().HasMaxLength(200);

        builder.HasOne(a => a.Customer)
            .WithMany(c => c.GlobalActivities)
            .HasForeignKey(a => a.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(a => a.Lead)
            .WithMany(l => l.GlobalActivities)
            .HasForeignKey(a => a.LeadId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(a => a.Deal)
            .WithMany(d => d.GlobalActivities)
            .HasForeignKey(a => a.DealId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(a => a.CreatedBy)
            .WithMany(u => u.GlobalActivities)
            .HasForeignKey(a => a.CreatedByUserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
