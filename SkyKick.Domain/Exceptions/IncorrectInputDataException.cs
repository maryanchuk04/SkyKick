namespace SkyKick.Domain.Exceptions;

public class IncorrectInputDataException : Exception
{
    public IncorrectInputDataException(string message) : base(message)
    {
        
    }
}