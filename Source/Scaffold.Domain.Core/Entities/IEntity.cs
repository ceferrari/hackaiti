namespace Scaffold.Domain.Core.Entities
{
    public interface IEntity
    {
        object id { get; set; }
    }

    public interface IEntity<out TIdentity> : IEntity
    {
        new TIdentity id { get; }
    }
}
