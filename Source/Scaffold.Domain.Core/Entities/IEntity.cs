namespace Scaffold.Domain.Core.Entities
{
    public interface IEntity
    {
        object Id { get; set; }
    }

    public interface IEntity<out TIdentity> : IEntity
    {
        new TIdentity Id { get; }
    }
}
