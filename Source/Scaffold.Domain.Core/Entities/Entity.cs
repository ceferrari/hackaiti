using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scaffold.Domain.Core.Entities
{
    public abstract class Entity<TIdentity> : IEntity<TIdentity>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public TIdentity Id { get; set; }
        object IEntity.Id
        {
            get => Id;
            set => Id = (TIdentity)value;
        }

        protected Entity() { }
        protected Entity(TIdentity id) => Id = id;

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<TIdentity>;
            return ReferenceEquals(this, compareTo) || compareTo is object && Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity<TIdentity> a, Entity<TIdentity> b) => a?.Equals(b) ?? b is null;
        public static bool operator !=(Entity<TIdentity> a, Entity<TIdentity> b) => !(a == b);
        public override int GetHashCode() => GetType().GetHashCode() * 907 + Id.GetHashCode();
        public override string ToString() => $"{GetType().Name} [Id={Id}]";
    }
}
