using context_pkg.Entities;
using Microsoft.EntityFrameworkCore;
using pkg_context.Context;
using pkg_context.Entities;
using pkg_context.Repositories.Interfaces;

namespace pkg_context.Repositories.Repository;

public class PartnerRepository : IPartnerRepository
{
    private readonly OpenAdmContext _openAdmContext;

    public PartnerRepository(OpenAdmContext openAdmContext)
    {
        _openAdmContext = openAdmContext;
    }

    public async Task<ConfigPartner?> GetPartnerByClientKeyAsync(Guid clientKey)
    {
        return await _openAdmContext
            .ConfigPartners
            .FirstOrDefaultAsync(x => x.ClientKey == clientKey);
    }
       

    public async Task<ConfigPartner?> GetPartnerByUrlAsync(string url)
    {
         return await _openAdmContext
            .ConfigPartners
            .FirstOrDefaultAsync(x => x.Url == url);

    }

}
