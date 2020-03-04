namespace Scaffold.Shared.ContextAcessors
{
    public interface ICorrelationIdContextAcessor
    {
        string GetUid();
        string GetCid();
    }
}
