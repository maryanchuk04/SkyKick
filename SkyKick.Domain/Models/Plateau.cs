using SkyKick.Domain.Exceptions;
using SkyKick.Domain.Interfaces;

namespace SkyKick.Domain.Models;

public class Plateau : IPlateau
{
    public Plateau(int upperBoundX, int upperBoundY)
    {
        UpperBoundX = upperBoundX;
        UpperBoundY = upperBoundY;
    }
    
    public int UpperBoundX { get; set; }
    public int UpperBoundY { get; set; }
}