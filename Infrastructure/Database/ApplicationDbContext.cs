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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            
            // Avoid reading/modifying the model metadata while it's being built. Instead, scan the assembly
            // for CLR types that implement ISoftDeletableEntity and apply a query filter for each.
            var softDeletableTypes = typeof(ApplicationDbContext).Assembly
                .GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && typeof(ISoftDeletableEntity).IsAssignableFrom(t))
                .ToList();

            foreach (var clrType in softDeletableTypes)
            {
                // build expression: (T e) => EF.Property<bool>(e, "IsDeleted") == false
                var parameter = Expression.Parameter(clrType, "e");
                var property = Expression.Property(parameter, nameof(ISoftDeletableEntity.IsDeleted));
                var filter = Expression.Lambda(Expression.Equal(property, Expression.Constant(false)), parameter);

                modelBuilder.Entity(clrType).HasQueryFilter(filter);
            }

        }
        
        
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.AddUlidConvention();
        }
    }
}
