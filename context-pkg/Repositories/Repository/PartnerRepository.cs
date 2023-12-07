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

    public async Task<Partner?> GetPartnerByClientKeyAsync(Guid clientKey)
    {
        return await _openAdmContext
            .Partners
            .Include(x => x.ConfigPartner)
            .FirstOrDefaultAsync(x => x.ConfigPartner.ClientKey == clientKey);
    }
       

    public async Task<Partner?> GetPartnerByUrlAsync(string url)
    {
         return await _openAdmContext
            .Partners
            .Include(x => x.ConfigPartner)
            .FirstOrDefaultAsync(x => x.ConfigPartner.Url == url);

    }

}
