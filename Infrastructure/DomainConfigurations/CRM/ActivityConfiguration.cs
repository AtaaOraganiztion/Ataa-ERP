using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Enums.CRM;
using Domain.Models.CRM;

public class ActivityConfiguration : IEntityTypeConfiguration<Domain.Models.CRM.Activity.Activity>
{
    public void Configure(EntityTypeBuilder<Domain.Models.CRM.Activity.Activity> builder)
    {
        builder.ToTable("Activity");
        builder.HasIndex(a => a.Type);
        builder.HasIndex(a => a.IsDeleted);


        builder.Property(a => a.Subject).IsRequired().HasMaxLength(200);



        builder.HasOne(a => a.Customer)
            .WithMany(c => c.Activities)
            .HasForeignKey(a => a.CustomerId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(a => a.Lead)
            .WithMany(l => l.Activities)
            .HasForeignKey(a => a.LeadId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(a => a.Deal)
            .WithMany(d => d.Activities)
            .HasForeignKey(a => a.DealId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(a => a.AssignedTo)
            .WithMany()
            .HasForeignKey(a => a.AssignedToUserId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(a => a.CreatedBy)
            .WithMany(u => u.Activities)
            .HasForeignKey(a => a.CreatedByUserId)
            .OnDelete(DeleteBehavior.NoAction);


    }
}
