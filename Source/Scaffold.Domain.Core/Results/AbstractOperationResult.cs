using System;
using Scaffold.Domain.Core.Events;

namespace Scaffold.Domain.Core.Results
{
    public abstract class AbstractOperationResult<TResult> : Event
    {
        public bool Success { get; }
        public TResult Data { get; }

        protected AbstractOperationResult(bool success, string message)
            : base(null, message)
        {
            Success = success;
        }

        protected AbstractOperationResult(bool success, TResult data, string message)
            : this(success, message)
        {
            Data = data;
        }

        public AbstractOperationResult<TResult> SetType(Type type)
        {
            Type = type.Name;
            return this;
        }
    }
}
