using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;
using Domain.Models.CRM.EmployeePerformanceReport;

namespace Infrastructure.DomainConfigurations.CRM;

public class EmployeePerformanceReportConfiguration : IEntityTypeConfiguration<EmployeePerformanceReport>
{
    public void Configure(EntityTypeBuilder<EmployeePerformanceReport> builder)
    {
        builder.ToTable("EmployeePerformanceReports");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Associations)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null) ?? new List<string>())
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.CorrespondenceStats)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<Dictionary<string, int>>(v, (JsonSerializerOptions)null) ?? new Dictionary<string, int>())
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.Projects)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null) ?? new List<string>())
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.KeyResults)
            .HasConversion(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null) ?? new List<string>())
            .HasColumnType("nvarchar(max)");

        builder.Property(x => x.EmployeeName).IsRequired().HasMaxLength(200);
        builder.Property(x => x.ReportDate).IsRequired().HasMaxLength(100);
    }
}
