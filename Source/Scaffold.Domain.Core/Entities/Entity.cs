using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scaffold.Domain.Core.Entities
{
    public abstract class Entity<TIdentity> : IEntity<TIdentity>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public TIdentity id { get; set; }
        object IEntity.id
        {
            get => id;
            set => id = (TIdentity)value;
        }

        protected Entity() { }
        protected Entity(TIdentity Id) => id = Id;

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<TIdentity>;
            return ReferenceEquals(this, compareTo) || compareTo is object && id.Equals(compareTo.id);
        }

        public static bool operator ==(Entity<TIdentity> a, Entity<TIdentity> b) => a?.Equals(b) ?? b is null;
        public static bool operator !=(Entity<TIdentity> a, Entity<TIdentity> b) => !(a == b);
        public override int GetHashCode() => GetType().GetHashCode() * 907 + id.GetHashCode();
        public override string ToString() => $"{GetType().Name} [id={id}]";
        public string ToJson() => JsonConvert.SerializeObject(this);
    }
}
