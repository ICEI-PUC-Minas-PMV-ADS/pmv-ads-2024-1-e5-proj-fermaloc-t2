﻿namespace Fermaloc.Application;

public class LoginException : Exception
{
    public LoginException(string? message) : base(message)
    {
    }

    public LoginException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
