namespace Test.Builder.Entities;

public class UserGroupBuilder
{
    private int? _maxUser;
    private int _number;
    private string _description;
    private readonly Guid _id;
    private readonly DateTime _created;
    private readonly DateTime _update;
    private readonly bool _active;
    public UserGroupBuilder()
    {
        var faker = new Faker();
        _maxUser = faker.Random.Int(min: 1);
        _description = "First group";
        _number = faker.Random.Int(min: 2);
        _id = Guid.NewGuid();
        _created = DateTime.Now;
        _update = DateTime.Now;
        _active = true;
    }

    public static UserGroupBuilder Init() => new();
    public UserGroup DeveCriarUserGroup(int maxUser, string description, int number)
    {
        return new(_id ,_created, _update, _active, number, maxUser, description);
    }

    public UserGroupBuilder SemDescription(string description)
    {
        _description = description;
        return this;
    }

    public UserGroupBuilder SemNumero(int number)
    {
        _number = number;
        return this;
    }

    public UserGroupBuilder SemMaxUser(int? maxUser)
    {
        _maxUser = maxUser;
        return this;
    }
    public UserGroup Build() => new(_id, _created, _update, _active, _number, _maxUser, _description);

}
