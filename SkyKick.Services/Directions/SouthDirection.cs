using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;

namespace SkyKick.Services.Directions;

public class SouthDirection : IDirection
{
    public IDirection RotateLeft() => new EastDirection();

    public IDirection RotateRight() => new WestDirection();

    public void MoveUp(Rover rover)
    {
        rover.Y -= 1;
    }
}