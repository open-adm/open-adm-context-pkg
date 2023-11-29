﻿using context_pkg.Exceptions;

namespace pkg_context.Validations;

public static class ValidateNumberZero
{
    public static void Validate(int number, string message)
    {
        if (number <= 0) throw new ExceptionCustom(message);
    }
}
