using System;
using System.Linq.Expressions;
using FluentValidation;
using FluentValidation.Results;
using Scaffold.Domain.Core.Entities;

namespace Scaffold.Domain.Core.Commands
{
    public abstract class Command<TIdentity, TEntity, TResult> : ICommand<TResult>
        where TEntity : IEntity
    {
        object ICommand.id
        {
            get => id;
            set => id = (TIdentity)value;
        }

        public TIdentity id { get; private set; }
        public Expression<Func<TEntity, bool>> Filter { get; }
        protected Command(TIdentity Id, Expression<Func<TEntity, bool>> filter = null)
        {
            id = Id;
            Filter = filter;
        }
        
        public ValidationResult ValidationResult { get; set; }
        public abstract bool IsValid();
        protected bool Validate(IValidator validator, ICommand command)
        {
            ValidationResult = validator.Validate(command);
            return ValidationResult.IsValid;
        }
    }
}
