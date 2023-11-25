namespace Test.Builder.Entities;

public class PermissionsGroupBuilder
{
    private string _description;
    private readonly bool _create;
    private readonly bool _update;
    private readonly bool _delete;
    private readonly bool _list;
    private Guid _userGroupId;
    private readonly int _number;

    public PermissionsGroupBuilder()
    {
        var faker = new Faker();
        _description = faker.Lorem.Paragraph();
        _create = true;
        _update = true;
        _delete = true;
        _list = true;
        _userGroupId = Guid.NewGuid();
        _number = faker.Random.Int(min: 1);
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

    public PermissionsGroup Build() => new(_description, _create, _update, _delete, _list, _userGroupId, _number);
}
