using BE.Domain.Abstractions.IEntities;

namespace BE.Domain.Abstractions
{
    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        public TKey? Id { get; set; }
    }
}
