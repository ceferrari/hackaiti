using FluentValidation;
using Scaffold.Domain.Core.Commands;
using System;

namespace Scaffold.Domain.Core.Validators
{
    public abstract class Validator<TCommand> : AbstractValidator<TCommand>
        where TCommand : ICommand
    {
        public Validator()
        {
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;
        }

        //public void ValidateId()
        //{
        //    RuleFor(c => c.id).NotEmpty();
        //}

        protected bool ValidateGuid(Guid guid)
        {
            return Guid.TryParse(guid.ToString(), out var result);
        }
    }
}
