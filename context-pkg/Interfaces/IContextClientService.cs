using pkg_context.Context;

namespace context_pkg.Interfaces;

public interface IContextClientService
{
    Task<ClientContext> CreateContextClient();
}
