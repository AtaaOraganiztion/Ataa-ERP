using Domain.Models.Adverisment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DomainConfigurations.Adverisment;

public class AdverismentConfiguration : IEntityTypeConfiguration<Domain.Models.Adverisment.Adverisment>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Adverisment.Adverisment> builder)
    {
        builder.ToTable("Adverisments");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Title)
            .HasMaxLength(200);

        builder.Property(a => a.Description)
            .HasMaxLength(2000);

        builder.Property(a => a.ImageUrl)
            .HasMaxLength(1000);

        builder.Property(a => a.Url)
            .HasMaxLength(1000);

        // FK to User
        builder
            .HasOne(a => a.User)
            .WithMany()
            .HasForeignKey(a => a.CreatedByUserId)
            .OnDelete(DeleteBehavior.NoAction);

        // Files relationship
        builder
            .HasMany(a => a.Files)
            .WithOne(f => f.Adverisment)
            .HasForeignKey(f => f.AdverismentId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(a => a.StartDate);

        builder.HasIndex(a => a.EndDate);

        builder.HasIndex(a => a.CreatedByUserId);

        builder.HasIndex(a => new { a.StartDate, a.EndDate });
    }
}

public class AdverismentFileConfiguration : IEntityTypeConfiguration<Domain.Models.Adverisment.Adverisment.AdverismentFile>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Adverisment.Adverisment.AdverismentFile> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.CreatedByUserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}