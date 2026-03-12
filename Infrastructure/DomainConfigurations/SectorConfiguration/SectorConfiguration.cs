using Domain.Models;
using Domain.Models.Sector;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DomainConfigurations.SectorConfiguration;

public class SectorConfiguration : IEntityTypeConfiguration<Sector>
{
    public void Configure(EntityTypeBuilder<Sector> builder)
    {
        builder
            .HasOne(x => x.Manager)
            .WithMany()
            .HasForeignKey(x => x.ManagerUserId);
    }
}