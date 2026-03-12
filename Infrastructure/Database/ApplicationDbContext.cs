using System;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Models;
using Infrastructure.Conventions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SharedKernel;
using SharedKernel.Common;
using Microsoft.AspNetCore.Identity;
using Domain.Models.Salary;
using Domain.Models.Sector;

namespace Infrastructure.Database
{
    public sealed class ApplicationDbContext : IdentityDbContext<User, Role, Ulid>
    {
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Domain.Models.Attendance.Attendance> Attendances { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            // Apply soft delete filter to all entities implementing ISoftDeletable
            foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDeletableEntity).IsAssignableFrom(entityType.ClrType))
                {
                    ParameterExpression parameter = Expression.Parameter(entityType.ClrType, "e");
                    MemberExpression property = Expression.Property(parameter, nameof(ISoftDeletableEntity.IsDeleted));
                    LambdaExpression filter =
                        Expression.Lambda(Expression.Equal(property, Expression.Constant(false)), parameter);

                    builder.Entity(entityType.ClrType).HasQueryFilter(filter);
                }
            }
        }
        
        
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.AddUlidConvention();
        }
    }
}
