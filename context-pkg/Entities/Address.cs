namespace context_pkg.Entities;

public sealed class Address
{
    public Address(Guid id, string? description, string zipCode, string? state, string? city, string? neighborhood, string road)
    {
        Id = id;
        Description = description;
        ZipCode = zipCode;
        State = state;
        City = city;
        Neighborhood = neighborhood;
        Road = road;
    }

    public Guid Id { get; private set; }
    public string? Description { get; private set; }
    public string ZipCode { get; private set; }
    public string? State { get; private set; }
    public string? City { get; private set; }
    public string? Neighborhood { get; private set; }
    public string Road { get; private set; }
}
