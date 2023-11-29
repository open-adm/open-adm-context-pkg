using Microsoft.Extensions.Caching.Memory;
using pkg_context.Entities;
using pkg_context.Repositories.Interfaces;
using pkg_context.Repositories.Repository;

namespace pkg_context.Repositories.Cached;

public class CachedPartner : IPartnerRepository
{
    private readonly PartnerRepository _partnerRepository;
    private readonly IMemoryCache _memoryCache;

    public CachedPartner(PartnerRepository partnerRepository, IMemoryCache memoryCache)
    {
        _partnerRepository = partnerRepository;
        _memoryCache = memoryCache;
    }

    public async Task<Partner?> GetPartnerByClientKeyAsync(Guid clientKey)
    {
        return await _memoryCache.GetOrCreateAsync(
        clientKey,
        cacheEntry =>
        {
            cacheEntry.SlidingExpiration = TimeSpan.FromHours(1);
            return _partnerRepository.GetPartnerByClientKeyAsync(clientKey);
        });
    }

    public async Task<Partner?> GetPartnerByUrlAsync(string url)
    {
        return await _memoryCache.GetOrCreateAsync(
        url,
        cacheEntry =>
        {
            cacheEntry.SlidingExpiration = TimeSpan.FromHours(1);
            return _partnerRepository.GetPartnerByUrlAsync(url);
        });
    }
}
