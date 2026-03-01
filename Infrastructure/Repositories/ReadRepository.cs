
using Application.Abstractions.Repositories;
using Ardalis.Specification.EntityFrameworkCore;
using Infrastructure.Database;

namespace Infrastructure.Repositories;

public class ReadRepository<TEntity>(ApplicationDbContext dbContext)
    : RepositoryBase<TEntity>(dbContext), IReadRepository<TEntity> where TEntity : class;
