

using SkyKick.Domain.Enum;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;

namespace SkyKick.Services.Command;

public class MoveUpCommand : ICommand
{
    public void Execute(Rover rover)
    {
        switch (rover.Direction)
        {
            case Direction.N:
                rover.Y += 1;
                break;
            case Direction.E:
                rover.X += 1;
                break;
            case Direction.S:
                rover.Y -= 1;
                break;
            case Direction.W:
                rover.X -= 1;
                break;
        }
    }
}