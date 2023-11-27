using pkg_context.Context;

namespace context_pkg.Strategy.Interfaces;

public interface IClientStrategy
{
    Task<ClientContext> CreateContextClient();
}
