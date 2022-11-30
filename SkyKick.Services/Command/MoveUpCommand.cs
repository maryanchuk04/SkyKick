

using SkyKick.Domain.Enum;
using SkyKick.Domain.Interfaces;
using SkyKick.Domain.Models;

namespace SkyKick.Services.Command;

public class MoveUpCommand : ICommand
{
    public void Execute(IRover rover)
    {
        switch (rover.CurrentPosition.Direction)
        {
            case Direction.N:
                rover.CurrentPosition.Y += 1;
                break;
            case Direction.E:
                rover.CurrentPosition.X += 1;
                break;
            case Direction.S:
                rover.CurrentPosition.Y -= 1;
                break;
            case Direction.W:
                rover.CurrentPosition.X -= 1;
                break;
        }
    }
}