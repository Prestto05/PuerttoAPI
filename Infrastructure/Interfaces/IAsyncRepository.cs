using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IAsyncRepository<TEntity, in TKey> where TEntity : Entity<TKey>
    {
        Task<TEntity> GetEntityByIdAsync(TKey id);

        Task<IReadOnlyList<TEntity>> ListAllAsync();

        Task<IReadOnlyList<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> orderBy = null,
            int page = 1,
            int pageSize = 0,
            params Expression<Func<TEntity, object>>[] includedProperties);

        Task<IReadOnlyList<TEntity>> AddAsync(params TEntity[] entities);

        Task UpdateAsync(TEntity entityToUpdate);

        Task UpsertAsync(params TEntity[] entities);

        Task DeleteAsync(TEntity entityToDelete);
    }

    public interface IAsyncRepositoryAlt<TEntity, in TKey> where TEntity : EntityWithAudit<TKey>
    {
        Task<TEntity> GetEntityByIdAsync(TKey id);

        Task<IReadOnlyList<TEntity>> ListAllAsync();

        Task<IReadOnlyList<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> orderBy = null,
            int page = 1,
            int pageSize = 0,
            params Expression<Func<TEntity, object>>[] includedProperties);

        Task<IReadOnlyList<TEntity>> AddAsync(params TEntity[] entities);

        Task UpdateAsync(TEntity entityToUpdate);

        Task UpsertAsync(params TEntity[] entities);

        Task DeleteAsync(TEntity entityToDelete);
    }
}
