using context_pkg.Entities;
using context_pkg.Entities.Bases;

namespace pkg_context.Entities;

public sealed class Company : BaseEntity
{
    public Company(Guid id, DateTime created_at, DateTime update_at, bool active, int number,
        string razaoSocial, string nameFantasy, string cnpj, string email, string? phone, Guid? addressId, bool isPremium) 
        : base(id, created_at, update_at, active, number)
    {
        RazaoSocial = razaoSocial;
        NameFantasy = nameFantasy;
        Cnpj = cnpj;
        Email = email;
        Phone = phone;
        AddressId = addressId;
        IsPremium = isPremium;
    }

    public void UpdateAddress(Guid addressId)
    {
        AddressId = addressId;
    }
    
    public string RazaoSocial { get; private set; }
    public string NameFantasy { get; private set; }
    public string Cnpj { get; private set; }
    public string Email { get; private set; }
    public string? Phone { get; private set; }
    public Guid? AddressId { get; private set; }
    public Address? Address { get; private set; }
    public bool IsPremium { get; private set; }
}
