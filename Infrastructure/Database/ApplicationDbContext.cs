using Domain.Identities.Entities;
using Infrastructure.Conventions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SharedKernel;
using System.Linq.Expressions;

namespace Infrastructure.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
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