using System;
using System.Collections.Generic;

namespace Dyvenix.Genit.Misc;

public class ValidationException : Exception
{
    public List<string> Errors { get; private set; }

    public ValidationException()
    {
        Errors = new List<string>();
    }

    public ValidationException(string message) : base(message)
    {
        Errors = new List<string>();
    }

    public ValidationException(string message, Exception innerException) : base(message, innerException)
    {
        Errors = new List<string>();
    }

    public ValidationException(List<string> errors)
    {
        Errors = errors ?? new List<string>();
    }

    public ValidationException(string message, List<string> errors) : base(message)
    {
        Errors = errors ?? new List<string>();
    }

    public ValidationException(string message, List<string> errors, Exception innerException) : base(message, innerException)
    {
        Errors = errors ?? new List<string>();
    }
}