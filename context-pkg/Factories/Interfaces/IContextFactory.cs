using pkg_context.Context;

namespace context_pkg.Factories.Interfaces;

public interface IContextFactory
{
    ClientContext CreateContextClient(byte[] stringConnectionByte);
}
