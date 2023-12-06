using context_pkg.Entities.Bases;

namespace context_pkg.Entities;

public sealed class AddressClient : BaseEntity
{
    public AddressClient(
        Guid id, 
        DateTime created_at, 
        DateTime update_at, 
        bool active, 
        int number,
        Guid clientId,
        Guid addressId) 
        : base(id, created_at, update_at, active, number)
    {
        ClientId = clientId;
        AddressId = addressId;
    }

    public Guid ClientId { get; private set; }
    public Client Client { get; set; } = null!;
    public Guid AddressId { get; private set; }
    public BaseAddress Address { get; set; } = null!;
}
