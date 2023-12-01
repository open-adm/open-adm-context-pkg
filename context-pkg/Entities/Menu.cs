namespace pkg_context.Entities;

public sealed class Menu
{
    public Menu(Guid id, bool isPremium)
    {
        Id = id;
        IsPremium = isPremium;
    }

    public Guid Id { get; private set; }
    public bool IsPremium { get; private set; }
    public List<Sidebar> Sidebar { get; set; } = new();
}
