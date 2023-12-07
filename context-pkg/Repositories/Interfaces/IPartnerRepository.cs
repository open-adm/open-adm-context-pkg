using context_pkg.Entities;

namespace pkg_context.Repositories.Interfaces;


public interface IPartnerRepository
{
    Task<ConfigPartner?> GetPartnerByUrlAsync(string url);
    Task<ConfigPartner?> GetPartnerByClientKeyAsync(Guid clientKey);
}

