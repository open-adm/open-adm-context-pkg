using context_pkg.Entities.Bases;

namespace pkg_context.Entities;

public sealed class Partner : BaseEntity
{
    public Partner(Guid id, DateTime created_at, DateTime update_at, bool active, int number,
        string razaoSocial, string nameFantasy, string cnpj, string email, string url, string db,
        Guid? addressId, Guid clientKey, bool isPremium) 
        : base(id, created_at, update_at, active, number)
    {
        RazaoSocial = razaoSocial;
        NameFantasy = nameFantasy;
        Cnpj = cnpj;
        Email = email;
        Url = url;
        Db = db;
        AddressId = addressId;
        ClientKey = clientKey;
        IsPremium = isPremium;
    }

    public string RazaoSocial { get; private set; }
    public string NameFantasy { get; private set; }
    public string Cnpj { get; private set; }
    public string Email { get; private set; }
    public string? Phone { get; private set; }
    public string Url { get; private set; }
    public string Db { get; private set; }
    public Guid? AddressId { get; private set; }
    public Address? Address { get; set; }
    public Guid ClientKey { get; private set; }
    public bool IsPremium { get; private set; }

    public void UpdateAddress(Guid addressId)
    {
        AddressId = addressId;
    }

    public void UpdateUrl(string url)
    {
        Url = url;
    }
}
