using context_pkg.Entities.Bases;

namespace context_pkg.Entities;

public sealed class Contact : BaseEntity
{
    public Contact(
        Guid id, 
        DateTime created_at, 
        DateTime update_at, 
        bool active, 
        int number,
        string? email,
        string? phone) 
        : base(id, created_at, update_at, active, number)
    {
        Email = email;
        Phone = phone;
    }

    public string? Email { get; private set; }
    public string? Phone { get; private set; }
}
