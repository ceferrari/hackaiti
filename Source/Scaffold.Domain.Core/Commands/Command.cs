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
            get => Id;
            set => Id = (TIdentity)value;
        }

        public TIdentity Id { get; private set; }
        public Expression<Func<TEntity, bool>> Filter { get; }
        protected Command(TIdentity id, Expression<Func<TEntity, bool>> filter = null)
        {
            Id = id;
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
