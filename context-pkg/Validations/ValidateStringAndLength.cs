using context_pkg.Exceptions;

namespace pkg_context.Validations;

public static class ValidateStringAndLength
{
    public static void Validate(string value, int length, string messageError)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ExceptionCustom(messageError);
        if (value.Length > length) throw new ExceptionCustom(messageError);
    }
}
