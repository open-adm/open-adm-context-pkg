using context_pkg.Entities.Bases;

namespace pkg_context.Entities;

public sealed class Permissions : BaseEntity
{
    public Permissions(Guid id, DateTime created_at, DateTime update_at, bool active, int number,
        bool isPremiu, string description) 
        : base(id, created_at, update_at, active, number)
    {
        Description = description;
        IsPremiun = isPremiu;
    }

    public bool IsPremiun { get; private set; }
    public string Description { get; private set; }
}
