namespace context_pkg.Exceptions;

public class ExceptionCustom : ArgumentNullException
{
    public ExceptionCustom(string? message) : base(message)
    {
    }
}
