﻿using application_pkg.Exceptions;
using context_pkg.Factories.Interfaces;
using context_pkg.Interfaces;
using Microsoft.AspNetCore.Http;
using pkg_context.Context;
using pkg_context.Repositories.Interfaces;

namespace context_pkg.Services;

public class ContextClientByClientKeyService : IContextClientService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IPartnerRepository _partnerRepository;
    private readonly IContextFactory _contextFactory;

    public ContextClientByClientKeyService(
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

        if (!Guid.TryParse(key, out Guid clientKey)) throw new Exception("clientKey inválida para criação do context do cliente!");

        var partner = await _partnerRepository.GetPartnerByClientKeyAsync(clientKey)
            ?? throw new ExceptionCustom($"Erro ao lozalizar a empresa com clientKey : {clientKey}, para criar context do cliente!");

        return _contextFactory.CreateContextClient(partner.Db);
    }
}