using pkg_context.Context;

namespace pkg_context.Factories;

public interface IFactory
{
    Task<ClientContext> CreateDatabaseByPathAsync();
    Task<ClientContext> CreateDatabaseByClientKeyAsync();
}
