using System;
using Scaffold.Domain.Core.Results;

namespace Scaffold.Domain.Core.Queries
{
    public interface IQueryHandler<in TQuery, TResult> : IDisposable
        where TQuery : IQuery
    {
        AbstractOperationResult<TResult> Handle(TQuery query);
    }
}
