using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;

namespace SkyKick.Services.Directions;

public class NorthDirection : IDirection
{
    public IDirection RotateLeft() => new WestDirection();
    
    public IDirection RotateRight() => new EastDirection();

    public void MoveUp(Rover rover)
    {
        rover.Y += 1;
    }
}