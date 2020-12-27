using System;

public class BadComponentException : Exception
{
    public BadComponentException()
    {
    }

    public BadComponentException(string message)
        : base(message)
    {
    }

    public BadComponentException(string message, Exception inner)
        : base(message, inner)
    {
    }
}