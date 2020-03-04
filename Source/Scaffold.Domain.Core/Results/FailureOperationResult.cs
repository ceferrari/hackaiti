namespace Scaffold.Domain.Core.Results
{
    public class FailureOperationResult<TResult> : AbstractOperationResult<TResult>
    {
        public FailureOperationResult(string message)
            : base(false, message)
        {

        }

        public FailureOperationResult(TResult data)
            : base(false, data, "Erro.")
        {

        }

        public FailureOperationResult(string message, TResult data)
            : base(false, data, message)
        {

        }
    }
}
