using SkyKick2._0.Interfaces;
using SkyKick2._0.Models;

namespace SkyKick2._0.Directions;

public class EastDirection : IDirection
{
    public IDirection RotateLeft() => new NorthDirection();

    public IDirection RotateRight() => new SouthDirection();

    public void MoveUp(Rover rover)
    {
        rover.X += 1;
    }

}