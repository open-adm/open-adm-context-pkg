namespace pkg_context.Entities;

public sealed class ChildrensSidebar
{
    public ChildrensSidebar(Guid id, string route, string title, string? icon, int order)
    {
        Id = id;
        Route = route;
        Title = title;
        Icon = icon;
        Order = order;
    }

    public Guid Id { get; set; }
    public string Route { get; set; }
    public string Title { get; set; }
    public string? Icon { get; set; }
    public int Order { get; set; }
}
