namespace context_pkg.Entities;

public sealed class Contact
{
    public Contact(
        Guid id,
        string? email,
        string? phone)
    {
        Id = id;
        Email = email;
        Phone = phone;
    }
    public Guid Id { get; private set; }
    public string? Email { get; private set; }
    public string? Phone { get; private set; }
}
