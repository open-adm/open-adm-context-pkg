using context_pkg.Entities;
using context_pkg.Entities.Bases;
using pkg_context.Cryptography;
using pkg_context.Validations;
using System.Text;
using System.Text.Json.Serialization;

namespace pkg_context.Entities;

public sealed class User : BasePerson
{
    [JsonConstructor]
    public User(Guid id, DateTime created_at, DateTime update_at, bool active, int number,
        string email, string password, string name, bool isAdmin, bool verifiedEmail, byte[]? avatar, Guid? userGroupId, string? cpf) 
        : base(id, created_at, update_at, active, number, email, name, cpf)
    {
        ValidateStringAndLength.Validate(password, 255, "Senha inválida!");
        ValidateBool.Validate(isAdmin, "É obrigatório informar se o usuário é admin!");
        ValidateNumberZero.Validate(number, "Número inválido!");

        Email = email;
        Password = password;
        Name = name;
        IsAdmin = isAdmin;
        VerifiedEmail = verifiedEmail;
        Avatar = avatar;
        UserGroupId = userGroupId;
    }

    public string Password { get; private set; }
    public bool IsAdmin { get; private set; }
    public bool VerifiedEmail { get; private set; }
    public byte[]? Avatar { get; private set; }
    public Guid? UserGroupId { get; private set; }
    public UserGroup? UserGroup { get; set; }
    public List<ContactUser> ContactUser { get; set; } = new();

    public void UpdateAccount(string? email, string name, string? avatar, string? cpf)
    {
        Email = email ?? Email;
        Name = name;
        Avatar = !string.IsNullOrWhiteSpace(avatar) ? Encoding.UTF8.GetBytes(avatar) : null;
        Cpf = cpf;
    }

    public void SetPasswordHash(string? newPassword = "")
    {
        Password = CryptographyPassword.Hash(string.IsNullOrWhiteSpace(newPassword) ? Password : newPassword);
    }

    public void ConfirmedEmail()
    {
        VerifiedEmail = true;
    }
}
