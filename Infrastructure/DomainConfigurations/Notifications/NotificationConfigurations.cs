using Domain.Models.Notifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DomainConfigurations.Notifications;

public class NotificationConfigurations : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notifications");

        builder.Property(x => x.Type)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(x => x.Message)
            .HasMaxLength(1000);

        builder.Property(x => x.EntityType)
            .HasMaxLength(100);

        builder.Property(x => x.Link)
            .HasMaxLength(500);

        builder.Property(x => x.CreatedAtUtc)
            .IsRequired();

        builder.Property(x => x.IsRead)
            .HasDefaultValue(false);
    }
}
