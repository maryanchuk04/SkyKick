namespace SkyKick.Domain.Exceptions;

public class PlateauIsNullException : Exception
{
    public PlateauIsNullException(string message) : base(message)
    {
    }
}