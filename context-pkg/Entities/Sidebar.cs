namespace pkg_context.Entities;

public sealed class Sidebar
{
    public Sidebar(Guid id, string? route, string title, string? icon, int order)
    {
        Id = id;
        Route = route;
        Title = title;
        Icon = icon;
        Order = order;
    }

    public Guid Id { get; private set; }
    public string? Route { get; private set; }
    public string Title { get; private set; }
    public string? Icon { get; private set; }
    public int Order { get; private set; }
    public List<ChildrensSidebar> Childrens { get; set; } = new ();
}
