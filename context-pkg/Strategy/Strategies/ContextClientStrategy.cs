using application_pkg.Exceptions;
using context_pkg.Interfaces;
using context_pkg.Services;
using context_pkg.Strategy.Interfaces;
using context_pkg.Validations;
using pkg_context.Context;

namespace context_pkg.Strategy.Strategies;

public class ContextClientStrategy : IContextClientStrategy
{
    private readonly IDictionary<string, IContextClientService> _services;

    public ContextClientStrategy(
        ContextClientByClientKeyService contextClientByClientKeyService,
        ContextClientByPathService contextClientByPathService)
    {
        _services = new Dictionary<string, IContextClientService>()
        {
            { "clientKey", contextClientByClientKeyService },
            { "path", contextClientByPathService }
        };
    }
        
    public async Task<ClientContext> CreateDatabase(string key)
    {
        ValidateStringIsNullOrEmpty.Validate(key);
        var result = _services.TryGetValue(key, out var service);
        if (!result || service is null) throw new ExceptionCustom(nameof(key));
        return await service.CreateContextClient();
    }
}
