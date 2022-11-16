using SkyKick.Domain.Exceptions;

namespace SkyKick.Domain.Models;

public class Plateau
{
    public const int LowerBoundX = 0;
    public const int LowerBoundY = 0;
    public int UpperBoundX { get; }
    public int UpperBoundY { get; }

    public Plateau(int upperBoundX, int upperBoundY)
    {
        ValidateInputCoordinates(upperBoundX, upperBoundY);
        UpperBoundX = upperBoundX;
        UpperBoundY = upperBoundY;
    }

    private void ValidateInputCoordinates(int x, int y)
    {
        if (x < LowerBoundX || y < LowerBoundY)
            throw new IncorrectInputDataException("Input coordinates for plateau is not correct!");
    }
}