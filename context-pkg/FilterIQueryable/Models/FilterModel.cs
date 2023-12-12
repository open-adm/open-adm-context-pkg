namespace context_pkg.FilterIQueryable.Models;

public abstract class FilterModel
{
    public string OrderBy { get; set; } = "Number";
    public bool Asc { get; set; } = false;
    public int? Skip { get; set; } = 1;
    public int? Take { get; set; } = 10;
}
