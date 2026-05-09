using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DomainConfigurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.ToTable("Projects");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Description)
            .HasMaxLength(2000);

        builder.Property(p => p.ProjectCode)
            .HasMaxLength(50);

        builder.Property(p => p.EstimatedBudget)
            .HasPrecision(18, 2);

        builder.Property(p => p.ActualCost)
            .HasPrecision(18, 2);

        builder.Property(p => p.CompletionPercentage)
            .HasPrecision(18, 2);

        builder.HasOne(p => p.Sector)
            .WithMany()
            .HasForeignKey(p => p.SectorId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.ProjectManager)
            .WithMany()
            .HasForeignKey(p => p.ProjectManagerId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
