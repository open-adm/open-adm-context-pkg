using application_pkg.Exceptions;
using context_pkg.Factories.Interfaces;
using context_pkg.Strategy.Interfaces;
using Microsoft.AspNetCore.Http;
using pkg_context.Context;
using pkg_context.Repositories.Interfaces;

namespace context_pkg.Strategy.Strategies;

public class ContextClientByPathService : IClientStrategy
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPartnerRepository _partnerRepository;
    private readonly IContextFactory _contextFactory;

    public ContextClientByPathService(
        IHttpContextAccessor httpContextAccessor,
        IPartnerRepository partnerRepository,
        IContextFactory contextFactory)
    {
        _httpContextAccessor = httpContextAccessor;
        _partnerRepository = partnerRepository;
        _contextFactory = contextFactory;
    }
    public async Task<ClientContext> CreateContextClient()
    {
        var url = _httpContextAccessor?.HttpContext?.Request.Headers["Referer"].ToString()
            ?? throw new ExceptionCustom("Erro ao recuperar path base da requisição, para criar o context do cliente!");

        var partner = await _partnerRepository.GetPartnerByUrlAsync(url)
            ?? throw new ExceptionCustom($"Erro ao localizar a empresa com a URL : {url}, para criar o context do cliente!");

        return _contextFactory.CreateContextClient(partner.Db);
    }
}
