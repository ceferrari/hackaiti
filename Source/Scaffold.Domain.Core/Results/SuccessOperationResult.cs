namespace Scaffold.Domain.Core.Results
{
    public class SuccessOperationResult<TResult> : AbstractOperationResult<TResult>
    {
        public SuccessOperationResult(string message)
            : base(true, message)
        {

        }

        public SuccessOperationResult(TResult data)
            : base(true, data, "Sucesso!")
        {

        }

        public SuccessOperationResult(string message, TResult data)
            : base(true, data, message)
        {

        }
    }
}
