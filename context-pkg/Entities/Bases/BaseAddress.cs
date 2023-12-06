namespace context_pkg.Entities.Bases;

public abstract class BaseAddress : BaseEntity
{
    public BaseAddress(Guid id, DateTime created_at, DateTime update_at, bool active, int number,
        string zipCode, string? state, string? city, string? neighborhood, string road, string? description)
        : base(id, created_at, update_at, active, number)
    {
        ZipCode = zipCode;
        State = state;
        City = city;
        Neighborhood = neighborhood;
        Road = road;
        Description = description;
    }
    public string? Description { get; private set; }
    public string ZipCode { get; private set; }
    public string? State { get; private set; }
    public string? City { get; private set; }
    public string? Neighborhood { get; private set; }
    public string Road { get; private set; }
}
