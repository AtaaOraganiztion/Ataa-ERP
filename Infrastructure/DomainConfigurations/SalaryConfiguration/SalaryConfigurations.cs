using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models.Salary;

namespace Infrastructure.DomainConfigurations.SalaryConfiguration;

public class SalaryConfigurations : IEntityTypeConfiguration<Domain.Models.Salary.Salary>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Salary.Salary> builder)
    {
        builder
            .HasIndex(b => b.BaseSalary);
        builder
            .HasIndex(b => b.NetSalary);
        
        
        builder
            .HasOne(e => e.Employee)
            .WithMany(s => s.Salaries)
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);

        // Map ConfirmedBy property to existing column name `ConfirmerId` and make it optional
        builder.Property(b => b.ConfirmedBy)
            .HasColumnName("ConfirmerId")
            .IsRequired(false);

        // Configure optional relation to Confirmer using the nullable FK property `ConfirmedBy`
        builder
            .HasOne(s => s.Confirmer)
            .WithMany() // no navigation on User back to salaries
            .HasForeignKey(s => s.ConfirmedBy) // use the actual property on the entity to avoid shadow FK
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);
        
    }
}