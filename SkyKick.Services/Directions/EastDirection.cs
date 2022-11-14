using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;

namespace SkyKick.Services.Directions;

public class EastDirection : IDirection
{
    public IDirection RotateLeft() => new NorthDirection();

    public IDirection RotateRight() => new SouthDirection();

    public void MoveUp(Rover rover)
    {
        rover.X += 1;
    }

}