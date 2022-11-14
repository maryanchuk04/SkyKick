namespace SkyKick2._0.Models;

public class Plateau
{
    public const int _lowerBoundX = 0;
    public const int _lowerBoundY = 0;
    public int UpperBoundX { get; }
    public int UpperBoundY { get; }

    public Plateau(int upperBoundX, int upperBoundY)
    {
        UpperBoundX = upperBoundX;
        UpperBoundY = upperBoundY;
    }
}