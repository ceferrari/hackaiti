using FluentValidation.Results;

namespace Scaffold.Domain.Core.Commands
{
    public interface ICommand
    {
        object Id { get; set; }
        ValidationResult ValidationResult { get; set; }
        bool IsValid();
    }

    public interface ICommand<TResult> : ICommand
    {
        
    }
}
