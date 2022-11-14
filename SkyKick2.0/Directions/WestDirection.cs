using SkyKick2._0.Interfaces;
using SkyKick2._0.Models;

namespace SkyKick2._0.Directions;

public class WestDirection : IDirection
{
    public IDirection RotateLeft() => new SouthDirection();


    public IDirection RotateRight() => new NorthDirection();

    public void MoveUp(Rover rover)
    {
        rover.X -= 1;
    }
}