using LotDesignerMicroservice.Domain.Entities.Base;
using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Base;
using Microsoft.EntityFrameworkCore;

namespace LotDesignerMicroservice.Infrastructure.EfRepository.Repositories.Base
{
    public abstract class EfRepository<TEntity, TKey>(ApplicationDbContext context)
        : IRepository<TEntity, TKey>
        where TEntity : Entity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public virtual async Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            EntityValidation(entity);
            context.Add(entity);
            await context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            EntityValidation(entity);
            context.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            await DeleteAsync(entity!, cancellationToken);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
            => await context.Set<TEntity>().ToListAsync(cancellationToken);

        public virtual async Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var foundEntity = await context.Set<TEntity>().FindAsync(id, cancellationToken);

            if (foundEntity is null)
                throw new ArgumentNullException(nameof(foundEntity), "Received entity is null");

            return foundEntity;
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            EntityValidation(entity);
            context.Update(entity);
            await context.SaveChangesAsync(cancellationToken);
        }

        protected virtual void EntityValidation(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity), "Received entity is null");
        }
    }
}