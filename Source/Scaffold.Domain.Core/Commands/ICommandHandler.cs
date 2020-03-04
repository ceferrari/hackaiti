using System;
using Scaffold.Domain.Core.Results;

namespace Scaffold.Domain.Core.Commands
{
    public interface ICommandHandler<in TCommand, TResult>
        where TCommand : ICommand
    {
        AbstractOperationResult<TResult> Handle(TCommand command);
    }
}
