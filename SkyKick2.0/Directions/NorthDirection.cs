using SkyKick2._0.Interfaces;
using SkyKick2._0.Models;

namespace SkyKick2._0.Directions;

public class NorthDirection : IDirection
{
    public IDirection RotateLeft() => new WestDirection();
    
    public IDirection RotateRight() => new EastDirection();

    public void MoveUp(Rover rover)
    {
        rover.Y += 1;
    }
}