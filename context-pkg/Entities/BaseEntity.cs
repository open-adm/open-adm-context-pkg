using context_pkg.Validations;
using pkg_context.Validations;

namespace pkg_context.Entities;

public abstract class BaseEntity
{
    protected BaseEntity(Guid id, DateTime created_at, DateTime update_at, bool active, int number)
    {
        ValidateNumberZero.Validate(number, "É obrigatório informar um número!");
        ValidateGuid.Validate(Id, "Id inválido!");
        Id = id;
        Created_at = created_at;
        Update_at = update_at;
        Active = active;
        Number = number;
    }

    public Guid Id { get; protected set; }
    public DateTime Created_at { get; protected set; }
    public DateTime Update_at { get; protected set; }
    public bool Active { get; protected set; }
    public int Number { get; protected set; }
}