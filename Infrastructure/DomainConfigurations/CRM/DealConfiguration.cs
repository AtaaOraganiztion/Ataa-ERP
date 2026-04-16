    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Domain.Enums.CRM;


    public class DealConfiguration : IEntityTypeConfiguration<Domain.Models.CRM.Deal.Deal>
    {
        public void Configure(EntityTypeBuilder<Domain.Models.CRM.Deal.Deal> builder)
        {
            builder.ToTable("Deal");
            builder.HasIndex(d => d.Status);
            builder.HasIndex(d => d.IsDeleted);

            builder.Property(d => d.Title).IsRequired().HasMaxLength(200);
            builder.Property(d => d.Value).HasPrecision(18, 2);

            builder.HasOne(d => d.Lead)
                .WithMany(l => l.Deals)
                .HasForeignKey(d => d.LeadId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.AssignedTo)
                .WithMany()
                .HasForeignKey(d => d.AssignedToUserId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(d => d.Customer)
            .WithMany(c => c.Deals)
            .HasForeignKey(d => d.CustomerId)
            .IsRequired(false)        
            .OnDelete(DeleteBehavior.SetNull);


    }
    }