using Ardalis.Specification;

namespace Application.Abstractions.Repositories;

public interface IReadRepository<TEntity> : IReadRepositoryBase<TEntity> where TEntity : class;
