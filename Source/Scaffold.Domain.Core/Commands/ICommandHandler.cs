using System;
using Scaffold.Domain.Core.Results;

namespace Scaffold.Domain.Core.Commands
{
    public interface ICommandHandler<in TCommand, TResult> : IDisposable
        where TCommand : ICommand
    {
        AbstractOperationResult<TResult> Handle(TCommand command);
    }
}
