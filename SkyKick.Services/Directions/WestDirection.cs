using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;

namespace SkyKick.Services.Directions;

public class WestDirection : IDirection
{
    public IDirection RotateLeft() => new SouthDirection();
    
    public IDirection RotateRight() => new NorthDirection();

    public void MoveUp(Rover rover)
    {
        rover.X -= 1;
    }
}