namespace Test.Builder.Entities;

public class PermissionsGroupBuilder
{
    private string _description;
    private readonly bool _create;
    private readonly bool _update;
    private readonly bool _delete;
    private readonly bool _list;
    private Guid _userGroupId;
    private Guid _permissionsId;
    private readonly int _number;
    private readonly Guid _id;
    private readonly DateTime _created;
    private readonly DateTime _updateDate;
    private readonly bool _active;

    public PermissionsGroupBuilder()
    {
        var faker = new Faker();
        _description = faker.Lorem.Paragraph();
        _create = true;
        _update = true;
        _delete = true;
        _list = true;
        _userGroupId = Guid.NewGuid();
        _permissionsId = Guid.NewGuid();
        _number = faker.Random.Int(min: 1);
        _id = Guid.NewGuid();
        _created = DateTime.Now;
        _updateDate = DateTime.Now;
        _active = true;
    }
    public static PermissionsGroupBuilder Init() => new();
    public PermissionsGroupBuilder SemDescription(string description)
    {
        _description = description;
        return this;
    }
    public PermissionsGroupBuilder SemGroupId(Guid groupId)
    {
        _userGroupId = groupId;
        return this;
    }

    public PermissionsGroup Build() => new(_id, _created, _updateDate, _active, _number, _description, _create, _update, _delete, _list, _userGroupId, _permissionsId);
}
