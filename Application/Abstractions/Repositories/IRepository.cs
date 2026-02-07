using Ardalis.Specification;

namespace Application.Abstractions.Repositories;

public interface IRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class;
