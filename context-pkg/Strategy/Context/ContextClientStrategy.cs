using application_pkg.Exceptions;
using context_pkg.Enum;
using context_pkg.Strategy.Interfaces;
using context_pkg.Strategy.Strategies;
using pkg_context.Context;

namespace context_pkg.Strategy.Context;

public class ContextClientStrategy : IContextClientStrategy
{
    private readonly IDictionary<TypeContextClient, IClientStrategy> _services;

    public ContextClientStrategy(
        ContextClientByClientKeyService contextClientByClientKeyService,
        ContextClientByPathService contextClientByPathService)
    {
        _services = new Dictionary<TypeContextClient, IClientStrategy>()
        {
            { TypeContextClient.ClientKey, contextClientByClientKeyService },
            { TypeContextClient.Path, contextClientByPathService }
        };
    }

    public async Task<ClientContext> CreateDatabase(TypeContextClient typeContextClient)
    {
        var result = _services.TryGetValue(typeContextClient, out var service);
        if (!result || service is null) throw new ExceptionCustom(nameof(typeContextClient));
        return await service.CreateContextClient();
    }
}
