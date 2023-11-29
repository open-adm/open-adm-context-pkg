using context_pkg.Validations;
using pkg_context.Validations;
using System.Text.Json.Serialization;

namespace pkg_context.Entities;

public sealed class PermissionsGroup : BaseEntity
{
    [JsonConstructor]
    public PermissionsGroup(string description, bool create, bool update, bool delete, bool list, Guid userGroupId, int number, Guid permissionsId) : base(number)
    {
        ValidateBool.Validate(create, "Parmetros inválidos");
        ValidateBool.Validate(update, "Parmetros inválidos");
        ValidateBool.Validate(delete, "Parmetros inválidos");
        ValidateBool.Validate(list, "Parmetros inválidos");
        ValidateStringAndLength.Validate(description, 255, "Descrição inválida!");
        ValidateGuid.Validate(userGroupId, "Informe o grupo!");
        Description = description;
        Create = create;
        Update = update;
        Delete = delete;
        List = list;
        UserGroupId = userGroupId;
        PermissionsId = permissionsId;
    }

    public string Description { get; private set; }
    public bool Create { get; private set; }
    public bool Update { get; private set; }
    public bool Delete { get; private set; }
    public bool List { get; private set; }
    public Guid UserGroupId { get; private set; }
    public Guid PermissionsId { get; private set; }
    public UserGroup UserGroup { get; private set; } = null!;
}
