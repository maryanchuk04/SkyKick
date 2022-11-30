using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;

namespace SkyKick.Domain.Models;

public class Plateau : IPlateau
{
    public Plateau(int upperBoundX, int upperBoundY)
    {
        ValidateInputCoordinates(upperBoundX, upperBoundY);
        UpperBoundX = upperBoundX;
        UpperBoundY = upperBoundY;
    }

    private void ValidateInputCoordinates(int x, int y)
    {
        if (x <= LowerBoundX || y <= LowerBoundY)
            throw new IncorrectInputDataException("Input coordinates for plateau is not correct!");
    }

    public int LowerBoundX => 0;
    public int LowerBoundY => 0;
    public int UpperBoundX { get; set; }
    public int UpperBoundY { get; set; }
}