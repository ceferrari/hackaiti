using Scaffold.Domain.Core.Bus;
using Scaffold.Domain.Core.Notifications;
using Scaffold.Domain.Core.Repositories;
using Scaffold.Domain.Core.Results;

namespace Scaffold.Domain.Core.Commands
{
    public abstract class CommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult>
        where TCommand : ICommand
    {
        protected readonly IBus Bus;
        protected readonly IRepository Repository;

        protected CommandHandler(IBus bus, IRepository repository)
        {
            Bus = bus;
            Repository = repository;
        }

        public abstract AbstractOperationResult<TResult> Handle(TCommand command);

        protected void NotifyValidationErrors(TCommand command)
        {
            foreach (var error in command.ValidationResult.Errors)
            {
                Bus.Notify(new Notification(command.GetType(), error.ErrorMessage));
            }
        }

        public bool Commit()
        {
            return Repository.Save() > 0;
        }

        public void Dispose()
        {
            Repository.Dispose();
        }
    }
}
