using context_pkg.Exceptions;

namespace context_pkg.Validations;

public static class ValidateStringIsNullOrEmpty
{
    public static void Validate(string value)
    {
        if (string.IsNullOrWhiteSpace(value)) throw new ExceptionCustom(nameof(value));
    }
}
