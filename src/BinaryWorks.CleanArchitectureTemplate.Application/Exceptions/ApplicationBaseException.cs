namespace BinaryWorks.CleanArchitectureTemplate.Application.Exceptions;

public class ApplicationBaseException : Exception
{
    protected ApplicationBaseException() : base()
    {
        
    }

    protected ApplicationBaseException(string message) : base(message)
    {
        
    }
}