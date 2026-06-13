using System.Runtime.Serialization;

namespace TLA.WebAPI.Exceptions;

public class TechnicalException : Exception
{
    public TechnicalException()
    {
    }

    public TechnicalException(string? message) : base(message)
    {
    }

    public TechnicalException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

#pragma warning disable SYSLIB0051 // Type or member is obsolete
    protected TechnicalException(SerializationInfo info, StreamingContext context) : base(info, context)
#pragma warning restore SYSLIB0051 // Type or member is obsolete
    {
    }
}
