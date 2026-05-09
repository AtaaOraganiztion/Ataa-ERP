using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models.CRM.GlobalActivity;

namespace Infrastructure.DomainConfigurations.CRM;

public class GlobalActivityFileConfiguration : IEntityTypeConfiguration<GlobalActivity.File>
{
    public void Configure(EntityTypeBuilder<GlobalActivity.File> builder)
    {
        builder.ToTable("GlobalActivityFiles");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FileName).IsRequired().HasMaxLength(255);
        builder.Property(x => x.StoragePath).IsRequired();
        builder.Property(x => x.ContentType).HasMaxLength(100);

        builder.HasOne(x => x.GlobalActivity)
            .WithMany(x => x.Files)
            .HasForeignKey(x => x.GlobalActivityId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.CreatedByUserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
