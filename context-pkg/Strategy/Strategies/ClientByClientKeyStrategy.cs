using context_pkg.Exceptions;
using context_pkg.Factories.Interfaces;
using context_pkg.Strategy.Interfaces;
using Microsoft.AspNetCore.Http;
using pkg_context.Context;
using pkg_context.Cryptography;
using pkg_context.Repositories.Interfaces;

namespace context_pkg.Strategy.Strategies;

public class ClientByClientKeyStrategy : IClientStrategy
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPartnerRepository _partnerRepository;
    private readonly IContextFactory _contextFactory;

    public ClientByClientKeyStrategy(
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
        var key = _httpContextAccessor?.HttpContext?.Request.Headers["clientKey"].ToString()
            ?? throw new ExceptionCustom("Erro ao recuperar clientKey da requisição,para criar o context do cliente!");

        var clientKeyString = CryptographyGeneric.Decrypt(key);

        if (!Guid.TryParse(clientKeyString, out Guid clientKey)) throw new Exception("clientKey inválida para criação do context do cliente!");

        var partner = await _partnerRepository.GetPartnerByClientKeyAsync(clientKey)
            ?? throw new ExceptionCustom($"Erro ao lozalizar a empresa com clientKey : {clientKey}, para criar context do cliente!");

        return _contextFactory.CreateContextClient(partner.ConfigPartner.Db);
    }
}
