using Application.Abstractions.Repositories;
using Ardalis.Specification.EntityFrameworkCore;
using Infrastructure.Database;

namespace Infrastructure.Repositories;

public class Repository<TEntity>(ApplicationDbContext dbContext)
    : RepositoryBase<TEntity>(dbContext), IRepository<TEntity> where TEntity : class;
