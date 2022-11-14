using SkyKick2._0.Interfaces;
using SkyKick2._0.Models;

namespace SkyKick2._0.Directions;

public class SouthDirection : IDirection
{
    public IDirection RotateLeft() => new EastDirection();

    public IDirection RotateRight() => new WestDirection();

    public void MoveUp(Rover rover)
    {
        rover.Y -= 1;
    }
}