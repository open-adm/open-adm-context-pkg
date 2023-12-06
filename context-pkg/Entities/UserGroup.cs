using context_pkg.Entities.Bases;
using pkg_context.Validations;

namespace pkg_context.Entities;

public sealed class UserGroup : BaseEntity
{
    public UserGroup(Guid id, DateTime created_at, DateTime update_at, bool active, int number,
        int? quantityMaxUser, string description) 
        : base(id, created_at, update_at, active, number)
    {
        ValidateStringAndLength.Validate(description, 255, "Informe a descrição!");
        if (quantityMaxUser != null)
            ValidateNumberZero.Validate(quantityMaxUser.Value, "Quantidade de usuários deve ser maior que zero!");
        QuantityMaxUser = quantityMaxUser;
        Description = description;
    }

    public int? QuantityMaxUser { get; private set; }
    public string Description { get; private set; }
    public List<PermissionsGroup> PermissionsGroups { get; set; } = new();
}
