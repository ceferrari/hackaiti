using FluentValidation;
using Scaffold.Domain.Core.Commands;

namespace Scaffold.Domain.Core.Validators
{
    public abstract class Validator<TCommand> : AbstractValidator<TCommand>
        where TCommand : ICommand
    {
        public Validator()
        {
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;
        }

        public void ValidateId()
        {
            RuleFor(c => c.id).NotEmpty();
        }
    }
}
