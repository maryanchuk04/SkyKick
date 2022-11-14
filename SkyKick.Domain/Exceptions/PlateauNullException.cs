namespace SkyKick.Domain.Exceptions;

public class PlateauNullException : Exception
{
    public PlateauNullException(string message) : base(message)
    {
    }
}