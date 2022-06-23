using Infrastructure.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    /// <summary>
    /// "There's some repetition here - couldn't we have some the sync methods call the async?"
    /// https://blogs.msdn.microsoft.com/pfxteam/2012/04/13/should-i-expose-synchronous-wrappers-for-asynchronous-methods/
    /// </summary>
    /// <typeparam name="TContext">Tipo de dato del Contexto de la Base de Datos.</typeparam>
    /// <typeparam name="TEntity">Tipo de dato de la entidad del repositorio.</typeparam>
    /// <typeparam name="TKey">Tipo de dato del ID de la entidad.</typeparam>
    public abstract class EntityFrameworkRepository<TContext, TEntity, TKey> : IAsyncRepository<TEntity, TKey>
        where TContext : DbContext
        where TEntity : Entity<TKey>
    {
        protected readonly TContext _dbContext;
        protected EntityFrameworkRepository(TContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Gets the first entity an object as key
        /// </summary>
        /// <param name="id">The id of the object you are looking for</param>
        /// <returns>An instance of the entity or null</returns>
        public virtual async Task<TEntity> GetEntityByIdAsync(TKey id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id).ConfigureAwait(true);
            return entity;
        }

        /// <summary>
        /// Gets all entities
        /// </summary>
        /// <returns>An readonly list of the type</returns>
        public virtual async Task<IReadOnlyList<TEntity>> ListAllAsync()
        {
            var entities = await _dbContext.Set<TEntity>().ToListAsync().ConfigureAwait(true);
            return entities;
        }

        /// <summary>
        /// Allows you to query an entity
        /// </summary>
        /// <param name="filter">Lambda expression for filtering rows</param>
        /// <param name="orderBy">Lambda expression for sorting</param>
        /// <param name="page">When pageSize is greater than 0 then will return
        ///     a particular data page</param>
        /// <param name="pageSize">Number of items per page.
        ///     0 will return all data without pages</param>
        /// <param name="includedProperties"></param>
        /// <param name=" includedProperties">Add an argument for each
        /// property that should be eager loaded</param>
        /// <returns>An readonly list of the type or null if no data is found</returns>
        public virtual async Task<IReadOnlyList<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int page = 1,
            int pageSize = 0,
            params Expression<Func<TEntity, object>>[] includedProperties)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includedProperties)
            {
                query.Include(includeProperty);
            }

            if (pageSize > 0)
            {
                query = query.Take(pageSize).Skip((page - 1) * pageSize);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync().ConfigureAwait(true);
            }

            var entities = await query.ToListAsync().ConfigureAwait(true);
            return entities;
        }

        /// <summary>
        /// Add a new entity or group of entities
        /// </summary>
        /// <param name="entities">Entity or entities that you would like to add</param>
        public virtual async Task<IReadOnlyList<TEntity>> AddAsync(params TEntity[] entities)
        {
            _dbContext.Set<TEntity>().AddRange(entities);
            await _dbContext.SaveChangesAsync().ConfigureAwait(true);
            return entities;
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entityToUpdate">Entity that you would like to update</param>
        public virtual async Task UpdateAsync(TEntity entityToUpdate)
        {
            _dbContext.Set<TEntity>().Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Intenta hacer un inserción de un arreglo de entidades a la base de datos, o actualizarlas si ya existen.
        /// </summary>
        /// <param name="entities">Las entidades a insertar o actualizar.</param>
        /// <returns></returns>
        public abstract Task UpsertAsync(params TEntity[] entities);

        /// <summary>
        /// Delete the entity
        /// </summary>
        /// <param name="entityToDelete">Entity that you wish to delete</param>
        public virtual async Task DeleteAsync(TEntity entityToDelete)
        {
            _dbContext.Set<TEntity>().Remove(entityToDelete);
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
        }


    }
}
