using FluentValidation;
using Scaffold.Domain.Core.Commands;

namespace Scaffold.Domain.Core.Validators
{
    public abstract class Validator<TCommand> : AbstractValidator<TCommand>
        where TCommand : ICommand
    {
        public void ValidateId()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
