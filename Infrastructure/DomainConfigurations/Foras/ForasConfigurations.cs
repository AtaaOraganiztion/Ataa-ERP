using Domain.Models.Foras;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DomainConfigurations.Foras;

public class ForasConfiguration : IEntityTypeConfiguration<Domain.Models.Foras.Foras>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Foras.Foras> builder)
    {
        builder.ToTable("Foras");

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
            .WithOne(f => f.Foras)
            .HasForeignKey(f => f.ForasId)
            .OnDelete(DeleteBehavior.Cascade);

        // Indexes
        builder.HasIndex(a => a.StartDate);

        builder.HasIndex(a => a.EndDate);

        builder.HasIndex(a => a.CreatedByUserId);

        builder.HasIndex(a => new { a.StartDate, a.EndDate });
    }
}

public class ForasFileConfiguration : IEntityTypeConfiguration<Domain.Models.Foras.Foras.ForasFile>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Foras.Foras.ForasFile> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.CreatedByUserId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
