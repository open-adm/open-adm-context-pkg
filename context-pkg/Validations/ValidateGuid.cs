using context_pkg.Exceptions;

namespace context_pkg.Validations;

public static class ValidateGuid
{
    public static void Validate(Guid? guid, string message)
    {
        if (guid == Guid.Empty || guid == null) throw new ExceptionCustom(message);
    }
}
