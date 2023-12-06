using context_pkg.Entities.Bases;

namespace context_pkg.Entities;

public sealed class Client : BasePerson
{
    public Client(
        Guid id, 
        DateTime created_at, 
        DateTime update_at, 
        bool active, 
        int number, 
        string email,
        string name, 
        string? cpf,
        DateTime? dateOfBirth,
        int? genero) 
        : base(id, created_at, update_at, active, number, email, name, cpf)
    {
        DateOfBirth = dateOfBirth;
        Genero = genero;
    }
    public DateTime? DateOfBirth { get; private set; }
    public int? Genero { get; private set; }

    public List<AddressClient> AddressClient { get; set; } = new();
}
