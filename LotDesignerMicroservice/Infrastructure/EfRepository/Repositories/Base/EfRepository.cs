﻿using LotDesignerMicroservice.Domain.Entities.Base;
using LotDesignerMicroservice.Domain.RepositoriesAbstractions.Base;
using Microsoft.EntityFrameworkCore;

namespace LotDesignerMicroservice.Infrastructure.EfRepository.Repositories.Base
{
    public abstract class EfRepository<TEntity, TKey>(ApplicationDbContext context)
        : IRepository<TEntity, TKey>
        where TEntity : Entity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        public virtual async Task<TKey?> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            await context.Set<TEntity>().AddAsync(entity, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public virtual async Task<bool> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            EntityValidation(entity);

            var entityForDelete = await GetByIdAsync(entity.Id, cancellationToken: cancellationToken);

            if (entityForDelete is null)
            {
                return false;
            }

            var entry = context.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);

            return entry.State == EntityState.Deleted;
        }

        public virtual async Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            return await DeleteAsync(entity!, cancellationToken);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
            => await context.Set<TEntity>().ToListAsync(cancellationToken);

        public virtual async Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
            => await context.Set<TEntity>().FindAsync([id, cancellationToken], cancellationToken: cancellationToken);

        public virtual async Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            var entityForUpdate = await GetByIdAsync(entity.Id, cancellationToken: cancellationToken);

            if (entityForUpdate is null)
            {
                return false;
            }

            var entry = context.Set<TEntity>().Update(entity);
            return await context.SaveChangesAsync(cancellationToken) > 0;
        }

        protected virtual void EntityValidation(TEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity), "Received entity is null");
        }
    }
}