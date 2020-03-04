using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Scaffold.Domain.Core.Entities;

namespace Scaffold.Domain.Core.Repositories
{
    public interface IReadOnlyRepository : IDisposable
    {
        #region GetAll
        IEnumerable<TEntity> GetAll<TEntity>(
            string orderBy = null,
            int? skip = null,
            int? take = null,
            string includeProperties = null,
            bool asNoTracking = true)
            where TEntity : class, IEntity;

        Task<IEnumerable<TEntity>> GetAllAsync<TEntity>(
            string orderBy = null,
            int? skip = null,
            int? take = null,
            string includeProperties = null,
            bool asNoTracking = true)
            where TEntity : class, IEntity;
        #endregion

        #region Get
        IEnumerable<TEntity> Get<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string orderBy = null,
            int? skip = null,
            int? take = null,
            string includeProperties = null,
            bool asNoTracking = true)
            where TEntity : class, IEntity;

        Task<IEnumerable<TEntity>> GetAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string orderBy = null,
            int? skip = null,
            int? take = null,
            string includeProperties = null,
            bool asNoTracking = true)
            where TEntity : class, IEntity;
        #endregion

        #region GetOne
        TEntity GetOne<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null,
            bool asNoTracking = true)
            where TEntity : class, IEntity;

        Task<TEntity> GetOneAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = null,
            bool asNoTracking = true)
            where TEntity : class, IEntity;
        #endregion

        #region GetFirst
        TEntity GetFirst<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string orderBy = null,
            string includeProperties = null,
            bool asNoTracking = true)
            where TEntity : class, IEntity;

        Task<TEntity> GetFirstAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null,
            string orderBy = null,
            string includeProperties = null,
            bool asNoTracking = true)
            where TEntity : class, IEntity;
        #endregion

        #region GetById
        TEntity GetById<TEntity>(
            object id,
            string includeProperties = null,
            bool asNoTracking = true)
            where TEntity : class, IEntity;

        Task<TEntity> GetByIdAsync<TEntity>(
            object id,
            string includeProperties = null,
            bool asNoTracking = true)
            where TEntity : class, IEntity;
        #endregion

        #region GetCount
        int GetCount<TEntity>(
            Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;

        Task<int> GetCountAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;
        #endregion

        #region GetExists
        bool GetExists<TEntity>(
            Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;

        Task<bool> GetExistsAsync<TEntity>(
            Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;
        #endregion
    }
}
