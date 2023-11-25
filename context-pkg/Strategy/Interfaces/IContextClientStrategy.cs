using pkg_context.Context;

namespace context_pkg.Strategy.Interfaces;

public interface IContextClientStrategy
{
    Task<ClientContext> CreateDatabase(string key);
}
