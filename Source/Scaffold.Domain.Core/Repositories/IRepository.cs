using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Scaffold.Domain.Core.Entities;

namespace Scaffold.Domain.Core.Repositories
{
    public interface IRepository : IReadOnlyRepository
    {
        #region Create
        TEntity Create<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        IEnumerable<TEntity> CreateRange<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IEntity;
        #endregion
        
        #region Update
        TEntity Update<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        IEnumerable<TEntity> UpdateRange<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IEntity;
        #endregion

        #region Merge
        TEntity Merge<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        IEnumerable<TEntity> MergeRange<TEntity>(IEnumerable<TEntity> entities)
            where TEntity : class, IEntity;
        #endregion

        #region Delete
        TEntity DeleteOne<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        TEntity DeleteById<TEntity>(object id)
            where TEntity : class, IEntity;

        IEnumerable<TEntity> Delete<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;
        #endregion

        #region SoftDelete
        TEntity SoftDeleteOne<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        TEntity SoftDeleteById<TEntity>(object id)
            where TEntity : class, IEntity;

        IEnumerable<TEntity> SoftDelete<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;
        #endregion

        #region Restore
        TEntity RestoreOne<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        TEntity RestoreById<TEntity>(object id)
            where TEntity : class, IEntity;

        IEnumerable<TEntity> Restore<TEntity>(Expression<Func<TEntity, bool>> filter = null)
            where TEntity : class, IEntity;
        #endregion

        #region Save and Commit
        int Save();

        Task<int> SaveAsync();

        bool Commit();

        Task<bool> CommitAsync();
        #endregion
    }
}
