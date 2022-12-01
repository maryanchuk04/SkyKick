namespace SkyKick.Domain.Interfaces;

public interface IPlateau
{
    const int LowerBoundX = 0;
    const int LowerBoundY = 0;
    int UpperBoundX { get; set; }
    int UpperBoundY { get; set; }
}