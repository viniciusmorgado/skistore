using SkiStore.Core.Base.Interfaces;

namespace SkiStore.Core.Base.Entities;

public class BaseEntity : IEntity
{
    public int Id { get; set; }
}
