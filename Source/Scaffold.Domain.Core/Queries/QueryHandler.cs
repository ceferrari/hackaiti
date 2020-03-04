using AutoMapper;
using Scaffold.Domain.Core.Repositories;
using Scaffold.Domain.Core.Results;

namespace Scaffold.Domain.Core.Queries
{
    public abstract class QueryHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery
    {
        protected readonly IMapper Mapper;
        protected readonly IReadOnlyRepository ReadOnlyRepository;

        protected QueryHandler(IMapper mapper, IReadOnlyRepository readOnlyRepository)
        {
            Mapper = mapper;
            ReadOnlyRepository = readOnlyRepository;
        }

        public abstract AbstractOperationResult<TResult> Handle(TQuery query);

        public void Dispose()
        {
            ReadOnlyRepository.Dispose();
        }
    }
}
