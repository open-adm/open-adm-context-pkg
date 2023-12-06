using context_pkg.Entities.Bases;

namespace context_pkg.Entities;

public sealed class AddressClient : BaseAddress
{
    public AddressClient(
        Guid id, 
        DateTime created_at, 
        DateTime update_at, 
        bool active, 
        int number, 
        string zipCode, 
        string? state, 
        string? city, 
        string? neighborhood, 
        string road, 
        string? description,
        Guid clientId,
        Guid addressId) 
        : base(id, created_at, update_at, active, number, zipCode, state, city, neighborhood, road, description)
    {
        ClientId = clientId;
        AddressId = addressId;
    }

    public Guid ClientId { get; private set; }
    public Client Client { get; set; } = null!;
    public Guid AddressId { get; private set; }
    public BaseAddress Address { get; set; } = null!;
}
