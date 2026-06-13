using System.Runtime.Serialization;

namespace TLA.WebAPI.Exceptions;

public class FunctionalException : Exception
{
    public FunctionalException()
    {
    }

    public FunctionalException(string? message) : base(message)
    {
    }

    public FunctionalException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

#pragma warning disable SYSLIB0051 // Type or member is obsolete
    protected FunctionalException(SerializationInfo info, StreamingContext context) : base(info, context)
#pragma warning restore SYSLIB0051 // Type or member is obsolete
    {
    }
}
