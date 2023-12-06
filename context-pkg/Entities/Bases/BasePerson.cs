
using pkg_context.Validations;

namespace context_pkg.Entities.Bases;

public abstract class BasePerson : BaseEntity
{
    protected BasePerson(Guid id, DateTime created_at, DateTime update_at, bool active, int number, string email, string name, string? cpf) 
        : base(id, created_at, update_at, active, number)
    {
        ValidateStringAndLength.Validate(name, 255, "Nome inválido!");
        ValidateEmailAndLength.Validate(email, 255, "Email inválido!");
        Email = email;
        Name = name;
        Cpf = cpf;
    }

    public string Email { get; protected set; }
    public string Name { get; protected set; }
    public string? Cpf { get; protected set; }
}
