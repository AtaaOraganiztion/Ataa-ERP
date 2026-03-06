using Domain.Models.Attendance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DomainConfigurations.Attendance;

public class AttendanceConfiguration : IEntityTypeConfiguration<Domain.Models.Attendance.Attendance>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Attendance.Attendance> builder)
    {
        builder.ToTable("Attendances");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.HoursWorked)
            .HasPrecision(5, 2);

        builder.Property(a => a.HoursToWork)
            .HasPrecision(5, 2);

        builder.Property(a => a.Notes)
            .HasMaxLength(500);

        // FK to Employee
        builder
            .HasOne(a => a.Employee)
            .WithMany()
            .HasForeignKey(a => a.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction);

        // FK to User (confirmer)
        builder
            .HasOne(a => a.Confirmer)
            .WithMany()
            .HasForeignKey(a => a.ConfirmedBy)
            .OnDelete(DeleteBehavior.NoAction);

        // Index for fast lookups by employee + date (most common query)
        builder.HasIndex(a => new { a.EmployeeId, a.Date });

        // Index for date-only queries (the date picker filter)
        builder.HasIndex(a => a.Date);
    }
}
