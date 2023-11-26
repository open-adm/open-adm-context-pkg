using System.Text.Json.Serialization;

namespace pkg_context.Entities;

public sealed class Permissions : BaseEntity
{
    [JsonConstructor]
    public Permissions(string description, bool isPremiun, int number) : base(number)
    {
        IsPremiun = isPremiun;
        Description = description;
    }
    public bool IsPremiun { get; set; }
    public string Description { get; private set; }
}
