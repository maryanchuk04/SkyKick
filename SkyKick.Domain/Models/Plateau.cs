namespace SkyKick.Domain.Models;

public class Plateau
{
    public const int LowerBoundX = 0;
    public const int LowerBoundY = 0;
    public int UpperBoundX { get; }
    public int UpperBoundY { get; }

    public Plateau(int upperBoundX, int upperBoundY)
    {
        UpperBoundX = upperBoundX;
        UpperBoundY = upperBoundY;
    }
}