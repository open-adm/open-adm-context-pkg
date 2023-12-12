namespace context_pkg.FilterIQueryable.Filters;

public static class FilterPaginate
{
    public static IQueryable<TEntity> Paginate<TEntity>(this IQueryable<TEntity> result, int? skip = 1, int? take = 0)
    {
        var newSkip = skip > 1 ? skip.Value : 1;
        var newTake = take > 0 ? take.Value : 10;

        if (newTake > 50) newTake = 50;

        return result.Skip((newSkip - 1) * newTake).Take(newTake);
    }
}
