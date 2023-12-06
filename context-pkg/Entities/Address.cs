
using context_pkg.Entities.Bases;

namespace context_pkg.Entities;

public sealed class Address : BaseAddress
{
    public Address(
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
        string? description) 
        : base(id, created_at, update_at, active, number, zipCode, state, city, neighborhood, road, description)
    {
    }
}
