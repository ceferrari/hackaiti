using Scaffold.Domain.Core.Repositories;
using Scaffold.Domain.Core.Results;

namespace Scaffold.Domain.Core.Queries
{
    public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery
    {
        //protected readonly IReadOnlyRepository ReadOnlyRepository;

        //protected QueryHandler(IReadOnlyRepository readOnlyRepository)
        //{
        //    ReadOnlyRepository = readOnlyRepository;
        //}

        public abstract AbstractOperationResult<TResult> Handle(TQuery query);

        //public void Dispose()
        //{
        //    ReadOnlyRepository.Dispose();
        //}
    }
}
