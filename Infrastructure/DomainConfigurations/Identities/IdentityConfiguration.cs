using Domain.Entities;
using Infrastructure.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SharedKernel;

namespace Infrastructure.DomainConfigurations.Identities;

public class IdentityConfiguration :
    IEntityTypeConfiguration<User>,
    IEntityTypeConfiguration<Role>,
    IEntityTypeConfiguration<UserRole>,
    IEntityTypeConfiguration<IdentityUserClaim<Ulid>>,
    IEntityTypeConfiguration<IdentityUserLogin<Ulid>>,
    IEntityTypeConfiguration<IdentityUserToken<Ulid>>,
    IEntityTypeConfiguration<IdentityRoleClaim<Ulid>>
{
    private readonly string _schema = Schemas.Identity;

    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", _schema);

        // Make Name optional (can be null in DB) but keep max length
        builder.Property(u => u.Name)
            .HasMaxLength(BaseConstraints.NameMaxLength);

        builder.HasMany(u => u.UserRoles)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }

    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("Roles", _schema);

        builder.HasMany(r => r.UserRoles)
            .WithOne(ur => ur.Role)
            .HasForeignKey(ur => ur.RoleId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
    }

    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.ToTable("UserRoles", _schema);
    }

    public void Configure(EntityTypeBuilder<IdentityUserClaim<Ulid>> builder)
    {
        builder.ToTable("UserClaims", _schema);
    }

    public void Configure(EntityTypeBuilder<IdentityUserLogin<Ulid>> builder)
    {
        builder.ToTable("UserLogins", _schema);
    }

    public void Configure(EntityTypeBuilder<IdentityUserToken<Ulid>> builder)
    {
        builder.ToTable("UserTokens", _schema);
    }

    public void Configure(EntityTypeBuilder<IdentityRoleClaim<Ulid>> builder)
    {
        builder.ToTable("RoleClaims", _schema);
    }
}