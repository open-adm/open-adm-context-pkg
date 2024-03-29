﻿using context_pkg.Factories.Factorie;
using context_pkg.Factories.Interfaces;
using context_pkg.Strategy.Context;
using context_pkg.Strategy.Interfaces;
using context_pkg.Strategy.Strategies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using pkg_context.Context;
using pkg_context.Repositories.Cached;
using pkg_context.Repositories.Interfaces;
using pkg_context.Repositories.Repository;

namespace pkg_context;

public static class ConfigureServicesContext
{
    public static IServiceCollection Inject(IServiceCollection services)
    {
        services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IContextFactory, ContextFactory>();
        services.AddScoped<IContextClientStrategy, ContextClientStrategy>();
        services.AddScoped<ClientByClientKeyStrategy>();
        services.AddScoped<ClientByPathStrategy>();
        services.AddScoped<PartnerRepository>();
        services.AddScoped<IPartnerRepository, CachedPartner>();
        services.AddMemoryCache();

        return services;
    }

    public static IServiceCollection InjectContext(IServiceCollection services, string stringConnection)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddDbContext<OpenAdmContext>(opt => opt.UseNpgsql(stringConnection));

        return services;
    }
}
