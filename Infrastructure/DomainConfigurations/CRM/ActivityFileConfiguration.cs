using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class ActivityFileConfiguration : IEntityTypeConfiguration<Domain.Models.CRM.Activity.Activity.File>
{
    public void Configure(EntityTypeBuilder<Domain.Models.CRM.Activity.Activity.File> builder)
    {
        builder.ToTable("Files");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FileName).IsRequired().HasMaxLength(255);
        builder.Property(x => x.StoragePath).IsRequired();
        builder.Property(x => x.ContentType).HasMaxLength(100);

        builder.HasOne(x => x.Activity)
            .WithMany(x => x.Files)
            .HasForeignKey(x => x.ActivityId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.CreatedByUserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}