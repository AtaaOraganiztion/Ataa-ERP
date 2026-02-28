using System;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure.Conventions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SharedKernel;
using SharedKernel.Common;

namespace Infrastructure.Data
{
    public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<User, Role, Ulid>(options)    {
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            
            // materialize the collection first to avoid modifying the model while enumerating it
            var entityTypes = modelBuilder.Model.GetEntityTypes().ToList();
            foreach (IMutableEntityType entityType in entityTypes)
            {
                if (typeof(ISoftDeletableEntity).IsAssignableFrom(entityType.ClrType))
                {
                    ParameterExpression parameter = Expression.Parameter(entityType.ClrType, "e");
                    MemberExpression property = Expression.Property(parameter, nameof(ISoftDeletableEntity.IsDeleted));
                    LambdaExpression filter =
                        Expression.Lambda(Expression.Equal(property, Expression.Constant(false)), parameter);

                    modelBuilder.Entity(entityType.ClrType).HasQueryFilter(filter);
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
