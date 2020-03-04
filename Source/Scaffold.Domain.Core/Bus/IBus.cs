using Scaffold.Domain.Core.Commands;
using Scaffold.Domain.Core.Notifications;
using Scaffold.Domain.Core.Queries;
using Scaffold.Domain.Core.Results;

namespace Scaffold.Domain.Core.Bus
{
    public interface IBus
    {
        void Notify(Notification notification);
        AbstractOperationResult<TResult> Request<TResult>(IQuery<TResult> query);
        AbstractOperationResult<TResult> Submit<TResult>(ICommand<TResult> command);
    }
}
