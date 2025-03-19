namespace Application.Exceptions;

public class MissingEnvironmentVariableException : Exception
{
    public MissingEnvironmentVariableException() : base()
    {

    }
    public MissingEnvironmentVariableException(string message) : base(message)
    {

    }
}