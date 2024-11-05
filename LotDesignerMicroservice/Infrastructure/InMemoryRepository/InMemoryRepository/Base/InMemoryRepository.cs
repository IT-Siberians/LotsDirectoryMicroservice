using LotDesignerMicroservice.Domain.Entities.Base;
using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Base;
using System.Collections.Immutable;

namespace LotDesignerMicroservice.Infrastructure.InMemoryRepository.Base
{
    public abstract class InMemoryRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : Entity<TKey> where TKey : struct, IEquatable<TKey>
    {
        public InMemoryRepository(IEnumerable<TEntity> entities)
        {
            if (entities is null)
                Entities = [];
            else
                Entities = entities.ToImmutableList();
        }

        protected ImmutableList<TEntity> Entities { get; set; }

        public virtual Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            EntityValidation(entity);
            Entities.Add(entity);
            return Task.CompletedTask;
        } 

        public virtual Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            EntityValidation(entity);
            Entities.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual async Task DeleteAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            await DeleteAsync(entity!, cancellationToken);
            return;
        }

        public virtual Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
            => Task.FromResult(Entities.AsEnumerable());

        public virtual Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var foundEntity = Entities.FirstOrDefault(x => x.Id.Equals(id));

            if (foundEntity is null)
                throw new ArgumentNullException(nameof(foundEntity), "Received entity is null");

            return Task.FromResult(foundEntity);
        }

        public virtual Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            EntityValidation(entity);
            var foundEntity = Entities.FirstOrDefault(x => x.Id.Equals(entity.Id));

            if (foundEntity is null)
                throw new ArgumentNullException(nameof(foundEntity), "Received entity is null");

            Entities.Replace(foundEntity, entity);
            return Task.CompletedTask;
        }

        protected virtual void EntityValidation(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity), "Received entity is null");
        }
    }
}
