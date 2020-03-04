using System;
using System.Linq.Expressions;

namespace Scaffold.Domain.Core.Queries
{
    public abstract class Query<TEntity, TResult> : IQuery<TResult>
    {
        public object Id { get; set; }
        public Expression<Func<TEntity, bool>> Filter { get; set; }
        public string OrderBy { get; set; }
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public string IncludeProperties { get; set; }
        public bool AsNoTracking { get; set; }

        protected Query(object id, string includeProperties = null, bool asNoTracking = true)
        {
            Id = id;
            IncludeProperties = includeProperties;
            AsNoTracking = asNoTracking;
        }

        protected Query(Expression<Func<TEntity, bool>> filter = null, string orderBy = null, int? skip = null, int? take = null, string includeProperties = null, bool asNoTracking = true)
            : this(null, includeProperties, asNoTracking)
        {
            Filter = filter;
            OrderBy = orderBy;
            Skip = skip;
            Take = take;
        }
    }
}
