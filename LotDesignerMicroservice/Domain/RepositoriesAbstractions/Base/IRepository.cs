using LotDesignerMicroservice.Domain.Entities.Base;

namespace LotDesignerMicroservice.Domain.RepositoriesAbstractions.Base
{
    public interface IRepository<TEntity, in TKey>
        where TEntity : Entity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken);
        Task CreateAsync(TEntity entity, CancellationToken cancellationToken);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);
        Task DeleteAsync(TKey id, CancellationToken cancellationToken);
    }
}
