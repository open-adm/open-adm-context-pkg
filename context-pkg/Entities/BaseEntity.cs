using context_pkg.Exceptions;
using System.Text.Json.Serialization;

namespace pkg_context.Entities;

public abstract class BaseEntity
{
    [JsonConstructor]
    public BaseEntity(int number)
    {
        if (number <= 0) throw new ExceptionCustom("Número inválido para a entidade!");
        Number = number;
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Created_at { get; set; } = DateTime.Now;
    public DateTime Update_at { get; set; } = DateTime.Now;
    public bool Active { get; set; } = true;
    public int Number { get; set; }
}