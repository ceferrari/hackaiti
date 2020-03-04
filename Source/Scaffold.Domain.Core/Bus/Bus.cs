using System;
using Scaffold.Domain.Core.Commands;
using Scaffold.Domain.Core.Logs;
using Scaffold.Domain.Core.Notifications;
using Scaffold.Domain.Core.Queries;
using Scaffold.Domain.Core.Results;
using Serilog;

namespace Scaffold.Domain.Core.Bus
{
    public class Bus : IBus
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly INotificationHandler _notificationHandler;

        public Bus(IServiceProvider serviceProvider, INotificationHandler notificationHandler)
        {
            _serviceProvider = serviceProvider;
            _notificationHandler = notificationHandler;
        }

        public void Notify(Notification notification)
        {
            _notificationHandler.Handle(notification);
        }

        public AbstractOperationResult<TResult> Request<TResult>(IQuery<TResult> query)
        {
            var queryType = query.GetType();
            try
            {
                var handlerType = typeof(IQueryHandler<,>).MakeGenericType(queryType, typeof(TResult));
                return ExecuteHandler<TResult>(handlerType, query, queryType);
            }
            catch (Exception ex)
            {
                return HandleException<TResult>(ex, queryType, true);
            }
        }

        public AbstractOperationResult<TResult> Submit<TResult>(ICommand<TResult> command)
        {
            var commandType = command.GetType();
            try
            {
                var handlerType = typeof(ICommandHandler<,>).MakeGenericType(commandType, typeof(TResult));
                return ExecuteHandler<TResult>(handlerType, command, commandType);
            }
            catch (Exception ex)
            {
                return HandleException<TResult>(ex, commandType, true);
            }
        }

        private AbstractOperationResult<TResult> ExecuteHandler<TResult>(Type handlerType, object argument, Type argumentType)
        {
            var handler = _serviceProvider.GetService(handlerType);
            if (handler == null)
            {
                throw new ArgumentException("Handler not registered for type " + argumentType.Name);
            }
            var handleMethod = handlerType.GetMethod("Handle", new[] { argumentType });
            return ((AbstractOperationResult<TResult>)handleMethod.Invoke(handler, new[] { argument })).SetType(argumentType);
        }

        private FailureOperationResult<TResult> HandleException<TResult>(Exception ex, Type argumentType, bool notify)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            var message = ex.Message;
            Log.Error(ex, "Unexpected Error {@data}");
            if (notify)
            {
                Notify(new Notification(argumentType, message));
            }
            return (FailureOperationResult<TResult>)new FailureOperationResult<TResult>(message, default).SetType(argumentType);
        }
    }
}
