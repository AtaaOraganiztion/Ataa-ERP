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
using Microsoft.AspNetCore.Identity;
using Domain.Models.Salary;
using Domain.Models.Sector;
using Domain.Models.Finance.Budget;
using Domain.Models.CRM.Customer;
using Domain.Models.CRM.Lead;
using Domain.Models.CRM.Deal;
using Domain.Models.CRM.Activity;

namespace Infrastructure.Database
{
    public sealed class ApplicationDbContext : IdentityDbContext<User, Role, Ulid>
    {
        public DbSet<Domain.Models.CRM.Customer.Customer> Customers { get; set; }
        public DbSet<Domain.Models.CRM.Lead.Lead> Leads { get; set; }
        public DbSet<Domain.Models.CRM.Deal.Deal> Deals { get; set; }
        public DbSet<Domain.Models.CRM.Activity.Activity> Activities { get; set; }
        public DbSet<Domain.Models.CRM.GlobalActivity.GlobalActivity> GlobalActivities { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Budget> budgets { get; set; }
        public DbSet<Domain.Models.Employee.Employee> Employees { get; set; }
        public DbSet<Domain.Models.Adverisment.Adverisment> Aderisments { get; set; }
        public DbSet<Domain.Models.Foras.Foras> Foras { get; set; }
        public DbSet<Activity.File> Files => Set<Activity.File>();
        public DbSet<Domain.Models.CRM.GlobalActivity.GlobalActivity.File> GlobalActivityFiles => Set<Domain.Models.CRM.GlobalActivity.GlobalActivity.File>();
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
            configurationBuilder.Properties<decimal>().HavePrecision(18, 2);
        }
    }
}
