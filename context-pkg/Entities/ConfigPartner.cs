namespace context_pkg.Entities;

public sealed class ConfigPartner
{
    public ConfigPartner(
        Guid id, 
        string url, 
        Guid clientKey, 
        bool isPremium, 
        string db, 
        Guid partnerId)
    {
        Id = id;
        Url = url;
        ClientKey = clientKey;
        IsPremium = isPremium;
        Db = db;
        PartnerId = partnerId;
    }

    public Guid Id { get; private set; }
    public string Url { get; private set; }
    public Guid ClientKey { get; private set; }
    public bool IsPremium { get; private set; }
    public string Db { get; private set; }
    public Guid PartnerId { get; private set; }
}
