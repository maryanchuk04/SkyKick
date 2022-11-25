namespace SkyKick.Domain.Exceptions;

public class RoverCoordinatesOutBoundsException : Exception
{
    public RoverCoordinatesOutBoundsException(string message) 
        : base(message)
    {
    }
} 