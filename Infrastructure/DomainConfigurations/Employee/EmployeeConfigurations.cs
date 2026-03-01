using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DomainConfigurations.Employee;

public class EmployeeConfigurations : IEntityTypeConfiguration<Domain.Models.Employee.Employee>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Employee.Employee> builder)
    {
        builder.ToTable("Employee");
        builder
            .HasIndex(b => b.EmployeeFirstName);
        builder
            .HasIndex(b => b.EmployeeEmail);   
        builder
            .HasIndex(b=> b.EmployeeNumber);
        builder
            .HasIndex(b=> b.EmployeeLastName);
        
        builder
            .HasOne(e => e.Sector)
            .WithMany(s => s.Employees)
            .HasForeignKey(e => e.SectorId)
            .OnDelete(DeleteBehavior.NoAction);
        
        
        builder
            .HasMany(e=> e.Salaries)
            .WithOne(e => e.Employee)
            .HasForeignKey(e => e.EmployeeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}