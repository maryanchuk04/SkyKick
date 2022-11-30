namespace SkyKick.Domain.Interfaces;

public interface IPlateau
{
    int LowerBoundX { get; }
    int LowerBoundY { get; }
    int UpperBoundX { get; set; }
    int UpperBoundY { get; set; }
}