using context_pkg.Entities.Bases;
using pkg_context.Entities;

namespace context_pkg.Entities;

public sealed class ContactUser : BaseEntity
{
    public ContactUser(
        Guid id, 
        DateTime created_at, 
        DateTime update_at, 
        bool active, 
        int number) 
        : base(id, created_at, update_at, active, number)
    {
    }

    public Guid UserId { get; private set; }
    public User User { get; set; } = null!;
    public Guid ContactId { get; private set; }
    public Contact Contact { get; set; } = null!;
}
