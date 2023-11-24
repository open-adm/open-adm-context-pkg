using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using pkg_context.Context;
using pkg_context.Factories;
using pkg_context.Repositories.Cached;
using pkg_context.Repositories.Interfaces;
using pkg_context.Repositories.Repository;

namespace pkg_context;

public static class ConfigureServicesContext
{
    public static IServiceCollection Inject(IServiceCollection services)
    {
        services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IFactory, Factory>();
        services.AddScoped<PartnerRepository>();
        services.AddScoped<IPartnerRepository, CachedPartner>();

        return services;
    }

    public static IServiceCollection InjectContext(IServiceCollection services, string stringConnection)
    {
        services.AddDbContext<OpenAdmContext>(opt => opt.UseNpgsql(stringConnection));

        return services;
    }
}
